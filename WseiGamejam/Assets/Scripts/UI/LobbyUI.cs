using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LobbyUI : MonoBehaviour
    {
        [Inject] private PlayerInputManager _playerInputManager;
        [Inject] private PlayerManager _playerManager;

        [SerializeField] private Image countdownDisplay;
        [SerializeField] private PlayerLobbyDisplayUI[] playerDisplays;
        [SerializeField] private float countdownTime = 2f;
        private Coroutine _countdownCoroutine;

        private void Start()
        {
            foreach (var player in _playerManager.Players)
            {
                OnPlayerJoined(player);
            }

            _playerManager.PlayerJoined += OnPlayerJoined;
        }

        private void OnPlayerJoined(Player player)
        {
            playerDisplays[player.Input.playerIndex].Initialize(player);

            player.OnPlayerReady += OnReadyChange;
            player.OnPlayerNotReady += OnReadyChange;
        }

        private void OnReadyChange()
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
            SceneManager.LoadScene("GameScene");
        }
    }
}