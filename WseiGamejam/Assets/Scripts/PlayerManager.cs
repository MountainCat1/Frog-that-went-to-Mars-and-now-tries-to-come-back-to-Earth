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
        Debug.Log("PLAyer manage is here!");
        
        DontDestroyOnLoad(gameObject);
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
                SpawnFrog();

                Runner.Input.SwitchCurrentActionMap("Runner");
            }
        }


        Debug.Log($"Player joined {input.playerIndex}");
    }

    void SpawnFrog()
    {
        var frogSpawner = FindObjectOfType<FrogSpawner>();
        var spawnPoint = frogSpawner.GetSpawnPoint();

        Frog frog = Instantiate(RunnerPrefab, spawnPoint, Quaternion.identity);
    }
    
    public void SpawnPlayers()
    {
        Instantiate(ShooterPrefab);
        Shooter.Input.enabled = true;
        Shooter.Input.SwitchCurrentActionMap("Shooter");

        Vector2 spawnPoint = Vector2.zero;

        var frogSpawner = FindAnyObjectByType<FrogSpawner>();
        spawnPoint = frogSpawner.GetSpawnPoint();

        Frog frog = Instantiate(RunnerPrefab, spawnPoint, Quaternion.identity);

        Runner.Input.enabled = true;
        Runner.Input.SwitchCurrentActionMap("Runner");
    }
}