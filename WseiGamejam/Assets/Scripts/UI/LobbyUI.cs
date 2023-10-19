using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LobbyUI : MonoBehaviour
    {
        private PlayerManager _playerManager;

        [SerializeField] private Image countdownDisplay;
        [SerializeField] private PlayerLobbyDisplayUI[] playerDisplays;
        [SerializeField] private float countdownTime = 2f;
        private Coroutine _countdownCoroutine;

        private void Start()
        {
            _playerManager = GameObject.FindObjectOfType<PlayerManager>();

            foreach (var player in _playerManager.Players)
            {
                OnPlayerJoined(player);
            }

            _playerManager.PlayerJoined += OnPlayerJoined;
        }

        private void OnDestroy()
        {
            if (_playerManager is not null)
            {
                _playerManager.PlayerJoined -= OnPlayerJoined;
                foreach (var lpPlayer in _playerManager.Players)
                {
                    lpPlayer.PlayerReady -= ReadyChange;
                    lpPlayer.PlayerNotReady -= ReadyChange;
                }
            }
        }

        private void OnPlayerJoined(Player player)
        {
            playerDisplays[player.Input.playerIndex].Initialize(player);

            player.PlayerReady += ReadyChange;
            player.PlayerNotReady += ReadyChange;
        }


        private void ReadyChange()
        {
            if (_playerManager.Players.TrueForAll(x => x.Ready) && _playerManager.Players.Count == 2)
            {
                StartCountdown();
            }
            else
            {
                StopCountdown();
            }
        }

        private void StopCountdown()
        {
            if (countdownDisplay is not null)
                countdownDisplay.fillAmount = 0;
            if (_countdownCoroutine is not null)
                StopCoroutine(_countdownCoroutine);
        }

        private void StartCountdown()
        {
            _countdownCoroutine = StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            var timer = 0f;
            while (timer < countdownTime)
            {
                timer += Time.deltaTime;
                countdownDisplay.fillAmount = timer / countdownTime;
                yield return new WaitForEndOfFrame();
            }

            StartGame();
        }

        private void StartGame()
        {
            Debug.Log("Game starting...");
            SceneManager.LoadScene(ConstValues.GameSceneName);
        }
    }
}