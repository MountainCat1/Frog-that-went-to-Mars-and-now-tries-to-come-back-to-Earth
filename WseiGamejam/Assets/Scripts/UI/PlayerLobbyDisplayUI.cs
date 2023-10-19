using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLobbyDisplayUI : MonoBehaviour
{
    [SerializeField] private GameObject disconnectedDisplay;
    [SerializeField] private GameObject connectedDisplay;
    
    [SerializeField] private Image readyDisplay;
    
    [SerializeField] private TextMeshProUGUI playerNameDisplay;

    private Player _player;
    
    public void Initialize(Player player)
    {
        _player = player;

        playerNameDisplay.text = $"Player {player.Input.playerIndex}";
     
        disconnectedDisplay.SetActive(false);
        connectedDisplay.SetActive(true);

        player.PlayerReady += PlayerReady;
        player.PlayerNotReady += PlayerNotReady;
    }

    private void OnDestroy()
    {
        _player.PlayerReady -= PlayerReady;
        _player.PlayerNotReady -= PlayerNotReady;
    }

    private void PlayerNotReady()
    {
        readyDisplay.color = Color.red;
    }

    private void PlayerReady()
    {
        readyDisplay.color = Color.green;
    }

}
