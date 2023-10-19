using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public void Start()
    {
        FindObjectOfType<PlayerManager>().SpawnPlayers();
    }
}