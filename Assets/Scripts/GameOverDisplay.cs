using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text winerNameText;
    [SerializeField] Button restartButton;

    private void OnEnable()
    {
        GameOverHandler.ClientGameOver += ClientOnGameOver;
        restartButton.onClick.AddListener(RestartGame); 
    }

    private void OnDisable()
    {
        GameOverHandler.ClientGameOver -= ClientOnGameOver; 
        restartButton.onClick.RemoveListener(RestartGame);
    }

    private void ClientOnGameOver(string winner)
    {
        canvas.enabled = true;
        winerNameText.text = $"{winner} won! ";
    }

    private void RestartGame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
            NetworkManager.singleton.StopHost();
        else
            NetworkManager.singleton.StopClient();
        
        canvas.enabled = false;
    }

}
