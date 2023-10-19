using System;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField] float jumpLength = 1f;

    [HideInInspector]
    public FrogSpawner frogSpawner;

    public void Awake()
    {
        frogSpawner = FindAnyObjectByType<FrogSpawner>();
    }

    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.RunnerPlayerInput.PlayerMoved += OnPlayerMoved;
    }

    private void LateUpdate()
    {
        var viewpointCoord = Camera.main.WorldToViewportPoint(transform.position);

        if (viewpointCoord.x < 0.0f || viewpointCoord.x > 1.0f)
        {
            TakeDamage();
        }
    }

    private void OnPlayerMoved(Vector2 vector)
    {
        if (transform.parent != null)
        {
            if (transform.parent.GetComponent<IObstacle>() is not null)
            {
                transform.SetParent(null);
            }
        }

        var delta = vector.normalized * jumpLength;
        transform.position += (Vector3)delta;
    }
    
    public void TakeDamage()
    {
        Debug.Log("Frog taking damage!");

        Vector2 newStartPoint = Vector2.zero;

        if (frogSpawner != null)
        {
            newStartPoint = frogSpawner.GetSpawnPoint();
        }

        transform.position = newStartPoint;
    }
}