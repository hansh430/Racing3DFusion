using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class PlayerController : NetworkBehaviour
{
    Rigidbody rb;
    Vector2 directionInput;
   // bool canSpawn;
    [SerializeField] float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void FixedUpdateNetwork()
    {
        if(GetInput(out NetworkInputData data))
        {
            directionInput = data.direction;
         //   canSpawn = data.isSpawn;
            print("1");
        //    print(canSpawn);

        }
        else
        {
            print("2");

            directionInput = Vector2.zero;
        }
       rb.velocity = directionInput*speed;
    }
}
