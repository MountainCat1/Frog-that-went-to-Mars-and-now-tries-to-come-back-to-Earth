using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public void Start()
    {
        GetComponent<PlayerManager>().SpawnPlayers();
    }
}