using System;
using ModestTree;
using UnityEngine;
using UnityEngine.EventSystems;

public class Frog : MonoBehaviour
{
    public static Frog Singleton { private set; get; }

    public static event Action FrogMoved;
    
    private PlayerManager _playerManager;

    [SerializeField] float jumpLength = 1f;

    [SerializeField] LayerMask layerMask;

    [HideInInspector]
    public FrogSpawner frogSpawner;

    public void Awake()
    {
        frogSpawner = FindAnyObjectByType<FrogSpawner>();
        
        if(Singleton)
            Debug.Log("Singleton pooped their pants!");

        Singleton = this;
    }

    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.RunnerPlayerInput.PlayerMoved += OnPlayerMoved;
    }

    private void Update()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.25f, layerMask);
        if(colliders.Length < 1)
        {
            TakeDamage(); 
        }
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
        FrogMoved?.Invoke();
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}