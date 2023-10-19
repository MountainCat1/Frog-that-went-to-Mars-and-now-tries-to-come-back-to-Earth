using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
   public event Action<Player> PlayerJoined;

   public List<Player> Players { get; private set; } = new List<Player>();

    public Player Shooter { get; set; }
    public ShooterPlayerInput ShooterPlayerInput { get; set; }
    public Player Runner { get; set; }
    public RunnerPlayerInput RunnerPlayerInput { get; set; }

    public void OnPlayerJoined(PlayerInput input)
   {
      var player = input.gameObject.GetComponentInParent<Player>();
      
      PlayerJoined?.Invoke(player);
      
      Players.Add(player);

        if (Shooter != null)
        {
            Shooter = player;
            ShooterPlayerInput = player.ShooterPlayerInput;
        }

        else
        {
            Runner = player;
            RunnerPlayerInput = player.RunnerPlayerInput;
        }
            

      Debug.Log($"Player joined {input.playerIndex}");
   }
}
