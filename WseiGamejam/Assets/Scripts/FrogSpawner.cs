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
        var pos = Vector2.Lerp(Start.position, End.position, randomFactor);

        return new Vector2(Mathf.RoundToInt(pos.x) + 0.5f, Mathf.RoundToInt(pos.y) - 0.5f);
    }
}
