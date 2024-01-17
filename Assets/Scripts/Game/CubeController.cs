using Fusion;
using NetworkInputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : NetworkBehaviour
{
    [SerializeField] private GameObject localSideParent;
    [SerializeField] private float force = 100f;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            localSideParent.SetActive(true);
        }
        else
        {
            Destroy(localSideParent);
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out CubeInputData data))
        {
            Movement(data);
        }
    }
    private void Movement(CubeInputData data)
    {
        var movement = new Vector3(data.Horizontal, 0, data.Vertical);
       
        rigidbody.AddForce(movement*force*Runner.DeltaTime);
        print(rigidbody);
    }
}
