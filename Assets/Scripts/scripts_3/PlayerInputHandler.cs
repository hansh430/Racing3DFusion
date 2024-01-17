using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public struct NetworkInputData: INetworkInput
{
    public Vector3 direction;
  //  public bool isSpawn;
}
public class PlayerInputHandler : MonoBehaviour
{
    Vector3 inputVector;
   // public bool space;
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
      //  space = Input.GetKeyDown(KeyCode.Space);
      
    }
    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();
        networkInputData.direction = inputVector;
     //   networkInputData.isSpawn = space;
        return networkInputData;
    }
}
