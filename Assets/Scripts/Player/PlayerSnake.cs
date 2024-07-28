using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner tspawner;

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
    }

}
