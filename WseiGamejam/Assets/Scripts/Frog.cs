using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Frog : MonoBehaviour
{
    private PlayerManager playerManager;

    [SerializeField] float jumpLength = 1f;

    public void Awake()
    {
    }
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerManager.RunnerPlayerInput.PlayerMoved += OnPlayerMoved;
    }
    private void OnPlayerMoved(Vector2 vector)
    {
        var delta = vector.normalized * jumpLength;
        transform.position += (Vector3)delta;
    }

    public void TakeDamage()
    {

    }

}
