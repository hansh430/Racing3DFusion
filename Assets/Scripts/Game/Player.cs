using Fusion;
using System;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private SimpleCarController carController;
    [SerializeField] private GameObject localComponent;
    [SerializeField] private CameraController cameraController;
    [Networked] public CarInputData inputData { get; set; }

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            localComponent.SetActive(true);
        }
        else
        {
            localComponent.SetActive(false);

        }
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out CarInputData data))
        {
            inputData = data;
        }
        carController.SetInputData(inputData);

    }

    internal void SetGameBall(Transform ballVisual)
    {
        cameraController.SetGameBall(ballVisual);
        print("2");

    }
}
    