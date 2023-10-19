using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Frog : MonoBehaviour
{
    [Inject] 
    private PlayerManager playerManager;

    public void Awake()
    {
        playerManager.RunnerPlayerInput.PlayerMoved += OnPlayerMoved;
    }

    private void OnPlayerMoved(Vector2 vector)
    {
        Debug.Log("Move");
        transform.position += new Vector3(vector.x, vector.y, 0f);
    }

    void Start()
    {
        
    }
}
