using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRow : MapRow
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] private float spawnCarDelay;
    [SerializeField] private float carSpeed;
    [SerializeField] private Trap trapPrefab;

    private Coroutine spawnTrapsCoroutine;
    
    private void Awake()
    {
        spawnTrapsCoroutine = StartCoroutine(SpawnTrapsCoroutine());
    }
    
    private IEnumerator SpawnTrapsCoroutine()
    {
        while (true)
        {
            SpawnTrap();
            yield return new WaitForSeconds(spawnCarDelay);
        }
    }

    private void SpawnTrap()
    {
        var trap = Instantiate(trapPrefab);
        trap.transform.position = start.position;

        trap.Initialize(end.position);
    }
}