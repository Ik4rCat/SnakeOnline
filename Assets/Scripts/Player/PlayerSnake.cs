using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tspawner;
    [SerializeField] PlayerName playerName;

    public static event Action<PlayerName> ServerPlayerSpawned;
    public static event Action<PlayerName> ServerPlayerDespawned;

    public override void OnStartServer()
    {
        ServerPlayerSpawned?.Invoke(playerName);
    }




    [Server]
    private void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent(out NetworkIdentity networkIdentity) &&
            networkIdentity.connectionToClient == connectionToClient) return;
        
        switch(other.tag)
        {
            case "Border":
            case "Player":
            case "Tail":
                DestroySelf();
                break;
            
        }
    }

    private void DestroySelf()
    {
        foreach(GameObject tail in tspawner.Tails)
        {
            NetworkServer.Destroy(tail);
        }

        NetworkServer.Destroy(gameObject);
        ServerPlayerDespawned?.Invoke(playerName);
    }

}
