using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SummaryUI : MonoBehaviour
    {
        private PlayerManager _playerManager;

        [SerializeField] private TextMeshProUGUI player0Score;
        [SerializeField] private TextMeshProUGUI player1Score;
        [SerializeField] private GameObject summary;
        [SerializeField] private GameObject change;
        
        private void Start()
        {
            _playerManager = FindObjectOfType<PlayerManager>();
            
            _playerManager.Runner.Input.SwitchCurrentActionMap("Common");
            _playerManager.Shooter.Input.SwitchCurrentActionMap("Common");

            if (_playerManager.Runner.FrogRounds == _playerManager.Runner.ShooterRounds)
            {
                summary.SetActive(true);
                change.SetActive(false);

                player0Score.text = _playerManager.Players[0].Score.ToString();
                player1Score.text = _playerManager.Players[1].Score.ToString();
            }
            else
            {
                summary.SetActive(false);
                change.SetActive(true);

            }
        }
    }
}