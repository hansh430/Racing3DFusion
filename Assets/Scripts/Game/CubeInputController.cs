using Fusion;
using Fusion.Sockets;
using NetworkInputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInputController : NetworkBehaviour, INetworkRunnerCallbacks
{
    private const string Horizontal = "Horizontal";
    private const string Vertical   = "Vertical";
    private float _horizontalValue;
    private float _verticalValue;
    public override void Spawned()
    {
        if(Object.HasInputAuthority)
        {
            Runner.AddCallbacks(this);
        }
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
       
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
       
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
       
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
       
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
       
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
       
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        _horizontalValue = Input.GetAxis(Horizontal);
        _verticalValue = Input.GetAxis(Vertical);

        var data = new CubeInputData()
        {
            Horizontal = _horizontalValue,
            Vertical = _verticalValue
        };
        input.Set(data);
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
       
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
       
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
       
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
       
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
       
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
       
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
       
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
       
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
