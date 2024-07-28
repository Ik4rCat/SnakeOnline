using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.VisualScripting;

public class GameOverHandler : NetworkBehaviour
{
    List<PlayerName> players = new List<PlayerName>();

    public override void OnStartServer()
    {
        PlayerSnake.ServerPlayerSpawned += ServerOnPlayerSpawned;
        PlayerSnake.ServerPlayerDespawned += ServerOnPlayerDespawned;
    }

    public override void OnStopServer()
    {
        PlayerSnake.ServerPlayerSpawned -= ServerOnPlayerSpawned;
        PlayerSnake.ServerPlayerDespawned -= ServerOnPlayerDespawned;
    }


    private void ServerOnPlayerSpawned(PlayerName player)
    {
        players.Add(player);
    }
    

    private void ServerOnPlayerDespawned(PlayerName player)
    {
        players.Remove(player);
        if(players.Count != 1) return;

        print(players[0].Name);
    }

}
