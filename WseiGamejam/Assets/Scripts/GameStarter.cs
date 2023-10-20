using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public void Start()
    {
        if (FindObjectOfType<PlayerManager>().Runner is null)
        {
            Debug.Log("skipping starting game probably you are debugging");
            return;
        }
        
        FindObjectOfType<PlayerManager>().SpawnPlayers();
    }
}