using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BloodSplashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplashPrefab;

    private void Start()
    {
        Frog.FromKilled += OnFromKilled;
    }

    private void OnFromKilled()
    {
        var position = Frog.Singleton.transform.position;
        var go = Instantiate(bloodSplashPrefab, position, Quaternion.identity);
        
        Destroy(go, 10);
    }
    
}
