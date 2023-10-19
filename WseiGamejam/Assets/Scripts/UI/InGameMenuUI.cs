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


    private void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        shooterScoreDisplay.text = _playerManager.Shooter.Score.ToString();
        runnerScoreDisplay.text = _playerManager.Runner.Score.ToString();
    }
}