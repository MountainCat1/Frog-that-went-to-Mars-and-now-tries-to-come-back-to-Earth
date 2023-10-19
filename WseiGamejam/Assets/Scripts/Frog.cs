using System;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField] float jumpLength = 1f;

    public void Awake()
    {
    }

    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.RunnerPlayerInput.PlayerMoved += OnPlayerMoved;
    }

    private void OnPlayerMoved(Vector2 vector)
    {
        var delta = vector.normalized * jumpLength;
        transform.position += (Vector3)delta;
    }
    
    public void TakeDamage()
    {
        Debug.Log("Frog taking damage!");
    }
}