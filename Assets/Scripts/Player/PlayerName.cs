using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] TMP_Text playerNameText;
    [SyncVar(hook = nameof(OnPlayerNameUpdated))] string playerName;

    public string Name { get { return playerName; } }

    public override void OnStartServer()
    {
        playerName = $"Player: {connectionToClient.connectionId}";
    }
    
    private void OnPlayerNameUpdated(string oldValue, string newValue)
    {
        playerNameText.text = newValue; 

    }

}
