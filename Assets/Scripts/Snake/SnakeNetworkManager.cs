using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] FoodSpawner foodSpawnerPrefab;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        if (numPlayers != 2) return;
        FoodSpawner fsp = Instantiate(foodSpawnerPrefab);
        NetworkServer.Spawn(fsp.gameObject);
    }
}
