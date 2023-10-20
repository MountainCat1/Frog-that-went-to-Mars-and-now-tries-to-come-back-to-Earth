using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shooterScoreDisplay;
    [SerializeField] private TextMeshProUGUI runnerScoreDisplay;
    [SerializeField] private TextMeshProUGUI timeDisplay;

    private PlayerManager _playerManager;
    private GameManager _gameManager;


    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(_playerManager.Runner is null)
            return;
        
        shooterScoreDisplay.text = _playerManager.Shooter.Score.ToString();
        runnerScoreDisplay.text = _playerManager.Runner.Score.ToString();
        timeDisplay.text = $"{_gameManager.RoundTime - _gameManager.Time}s";
    }
}