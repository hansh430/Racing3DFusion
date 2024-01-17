using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NetworkSpawnerController : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef gameBallNetworkPrefab;
    [SerializeField] private NetworkPrefabRef playerNetworkPrefab;
    [SerializeField] private TMP_Text roomCodeText;
    [SerializeField, Range(0f, 10f)]
    private NetworkManager networkManager;
    private float randomSpawnPositionRange = 5f;
    private List<NetworkObject> _spawnedBallObjects = new List<NetworkObject>();
    private Dictionary<PlayerRef, NetworkObject> cubePlayers = new Dictionary<PlayerRef, NetworkObject>();
    private NetworkObject _ball;
    private Transform _ballVisual;

    private void Start()
    {
          networkManager = FindAnyObjectByType<NetworkManager>();
    }
    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            SpawnGameBall();
        }
    }

    private void SpawnGameBall()
    {
        var pos = new Vector3(0, 2f, 0);
        var _ball = Runner.Spawn(gameBallNetworkPrefab, pos, Quaternion.identity);
        _ballVisual = _ball.transform.GetChild(0).transform;
    }

    

    public void PlayerJoined(PlayerRef player)
    {
        roomCodeText.text = "Room Code: "+networkManager.roomCode;
        if (Runner.IsServer)
        {
           SpawnPlayerObject(player);
        }
    }

    private void SpawnPlayerObject(PlayerRef player)
    {
        var randomPos = new Vector3(Random.Range(-randomSpawnPositionRange, randomSpawnPositionRange), 2f, Random.Range(-randomSpawnPositionRange, randomSpawnPositionRange));
        var playerNetworkObj = Runner.Spawn(playerNetworkPrefab, randomPos, Quaternion.identity, player);
        cubePlayers.Add(player, playerNetworkObj);
        var playerScript = playerNetworkObj.GetComponent<Player>();
        playerScript.SetGameBall(_ballVisual);
        print("1");
    }

    public void PlayerLeft(PlayerRef player)
    {
      if(Runner.IsServer)
        {
            DeSpawnPlayerObject(player);
        }
    }

    private void DeSpawnPlayerObject(PlayerRef player)
    {
       if(cubePlayers.TryGetValue(player, out var demoObj))
        {
            Runner.Despawn(demoObj);
            cubePlayers.Remove(player);
        }
    }
}
