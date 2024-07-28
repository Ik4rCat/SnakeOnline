using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] GameObject tailPrefab;
    

    public List<GameObject> Tails { get; } = new List<GameObject>();


    public override void OnStartServer()
    {
        Food.ServerFoodEaten += AddTail;
    }

    public override void OnStopServer()
    {
        Food.ServerFoodEaten -= AddTail;
    }

    public void AddTail(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject) return;

        GameObject tail = Instantiate(tailPrefab);
        NetworkServer.Spawn(tail,connectionToClient);
    }
}
