using System.Collections;
using UnityEngine;

public class ObstacleRow : MapRow
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    [SerializeField] private float spawnCarDelay;
    [SerializeField] private float trapSpeed;
    [SerializeField] private float trapAcceleration;
    [SerializeField] private GameObject trapPrefab;

    private Coroutine _spawnTrapsCoroutine;
    
    private void Awake()
    {
        _spawnTrapsCoroutine = StartCoroutine(SpawnTrapsCoroutine());
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

        trap.GetComponent<IObstacle>().Initialize(end.position, trapSpeed, trapAcceleration);
    }
}

public interface IObstacle
{
    public void Initialize(Vector3 destination, float speed = 1f, float acceleration = 1f);
}