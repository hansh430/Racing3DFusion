using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EditorButton;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ballCamera;
    [SerializeField] private CinemachineVirtualCamera carCamera;
    private bool isCarCameraActive;

    private void Start()
    {
        isCarCameraActive = true;
        UpdateCameraStates();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCamera();
        }
    }

    private void UpdateCameraStates()
    {
        if (isCarCameraActive)
        {
            carCamera.Priority = 1;
            ballCamera.Priority = 0;
        }
        else
        {
            carCamera.Priority = 0;
            ballCamera.Priority = 1;
        }
    }
    [Button]
    private void ToggleCamera()
    {
        isCarCameraActive = !isCarCameraActive;
        UpdateCameraStates();
    }

    internal void SetGameBall(Transform ballVisual)
    {
        ballCamera.LookAt = ballVisual;
        print("3");

    }
}
