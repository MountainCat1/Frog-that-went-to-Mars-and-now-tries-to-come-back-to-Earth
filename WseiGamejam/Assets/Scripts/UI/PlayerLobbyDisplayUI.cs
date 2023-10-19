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

        player.OnPlayerReady += () =>
        {
            readyDisplay.color = Color.green;
        };
        player.OnPlayerNotReady += () =>
        {
            readyDisplay.color = Color.red;
        };
    }
}
