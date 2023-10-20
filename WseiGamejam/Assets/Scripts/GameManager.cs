using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FinishLine finishLine;

    [SerializeField] private int scoreForFrogEscape = 100;
    [SerializeField] private int scoreForKillingFrog = 100;
    [SerializeField] private int scoreForFrogDead = 20;
    [field: SerializeField] public int RoundTime { get; private set; } = 60;
    [field: SerializeField] public int Time { get; private set; } = 0;

    private PlayerManager _playerManager;

    private Coroutine _roundTimeCoroutine;

    private void Start()
    {
        finishLine.FrogEscaped += FrogEscaped;
        _playerManager = FindObjectOfType<PlayerManager>();
        Frog.FromKilled += OnFrogDead;

        _roundTimeCoroutine = StartCoroutine(RoundTimeCoroutine());
    }

    private void OnDestroy()
    {
        finishLine.FrogEscaped -= FrogEscaped;
        Frog.FromKilled -= OnFrogDead;
    }

    private IEnumerator RoundTimeCoroutine()
    {
        while (Time <= RoundTime)
        {
            yield return new WaitForSeconds(1);
            Time++;
        }

        EndRound();
    }

    private void EndRound()
    {
        Debug.Log("Round end!");
        
        
        // swap players
        (_playerManager.Runner, _playerManager.Shooter) = (_playerManager.Shooter, _playerManager.Runner);
        _playerManager.ShooterPlayerInput = _playerManager.Shooter.ShooterPlayerInput;
        _playerManager.RunnerPlayerInput = _playerManager.Runner.RunnerPlayerInput;
        _playerManager.Shooter.Input.SwitchCurrentActionMap("Shooter");
        _playerManager.Runner.Input.SwitchCurrentActionMap("Runner");

        SceneManager.LoadScene(ConstValues.SummaryScene);
    }

    private void FrogEscaped()
    {
        Frog.Singleton.Remove();

        _playerManager.Runner.Score += scoreForFrogEscape;
    }

    private void OnFrogDead()
    {
        _playerManager.Shooter.Score += scoreForFrogDead;

    }
}