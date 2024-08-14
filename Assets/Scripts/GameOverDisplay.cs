using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverDisplay : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_Text winerNameText;

    private void OnEnable()
    {
        GameOverHandler.ClientGameOver += ClientOnGameOver;
    }

    private void OnDisable()
    {
        GameOverHandler.ClientGameOver -= ClientOnGameOver; 
    }

    private void ClientOnGameOver(string winner)
    {
        canvas.enabled = true;
        winerNameText.text = $"{winner} won! ";
    }

}
