using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FinishLine finishLine;
    
    [SerializeField] private int scoreForFrogEscape = 100;
    [SerializeField] private int scoreForKillingFrog = 100;
    
    private PlayerManager _playerManager;
    
    private void Start()
    {
        finishLine.FrogEscaped += FrogEscaped;
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    private void FrogEscaped()
    {
        Frog.Singleton.Remove();

        _playerManager.Runner.Score += scoreForFrogEscape;
    }
}