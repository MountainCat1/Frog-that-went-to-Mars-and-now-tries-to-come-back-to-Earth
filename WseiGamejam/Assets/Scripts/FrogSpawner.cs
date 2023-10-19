using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform Start;

    [SerializeField]
    private Transform End;

    public Vector2 GetSpawnPoint()
    {
        float randomFactor = Random.Range(0.0f, 1.0f);
        return Vector2.Lerp(Start.position, End.position, randomFactor);
    }
}
