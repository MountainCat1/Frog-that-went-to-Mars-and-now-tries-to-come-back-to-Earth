using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
   public event Action<Player> PlayerJoined;

   public List<Player> Players { get; private set; } = new List<Player>();

    public Player Shooter { get; set; }
    public ShooterPlayerInput ShooterPlayerInput { get; set; }
    public Player Runner { get; set; }
    public RunnerPlayerInput RunnerPlayerInput { get; set; }

    [SerializeField] private Frog RunnerPrefab;
    [SerializeField] private Scope ShooterPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(this);
    }

    public void OnPlayerJoined(PlayerInput input)
   {
      var player = input.gameObject.GetComponentInParent<Player>();
      
      PlayerJoined?.Invoke(player);
      
      Players.Add(player);

      player.transform.parent = transform;

        if (Shooter == null)
        {
            Shooter = player;
            ShooterPlayerInput = player.ShooterPlayerInput;
            if (Utilities.IsInGameScene)
            {
                Shooter.Input.SwitchCurrentActionMap("Shooter");
                Instantiate(ShooterPrefab);
            }
        }
        else if (Runner == null)
        {
            Runner = player;
            RunnerPlayerInput = player.RunnerPlayerInput;
            if (Utilities.IsInGameScene)
            {
                Instantiate(RunnerPrefab);
                Runner.Input.SwitchCurrentActionMap("Runner");
            }
        }
            

      Debug.Log($"Player joined {input.playerIndex}");
   }

    public void SpawnPlayers()
    {
        Instantiate(ShooterPrefab);
        Debug.Log(Shooter);
        Debug.Log(Shooter.Input);
        Shooter.Input.enabled = true;
        Shooter.Input.SwitchCurrentActionMap("Shooter");

        Instantiate(RunnerPrefab);
        Runner.Input.enabled = true;
        Runner.Input.SwitchCurrentActionMap("Runner");
    }
}
