using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer Local { get; set; }

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;
            Debug.Log("Local Player spawned");

        }
        else
        {
            Debug.Log("Client Player spawned");
        }
    }
    public void PlayerLeft(PlayerRef player)
    {
        if(player == Object.HasInputAuthority )
        {
            Runner.Despawn(Object);
        }
    }

}
