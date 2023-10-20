using System;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public static Frog Singleton { private set; get; }

    public static event Action FrogMoved;
    public static event Action FromRemoved;
    public static event Action FromKilled;
    
    private PlayerManager _playerManager;
    private Player _runner;
    private FrogSpawner _spawner;

    [SerializeField] float jumpLength = 1f;

    [SerializeField] LayerMask layerMask;

    private bool dead = false;
    private bool removed = false;
    
    public void Awake()
    {
        if (Singleton)
        {
            Debug.Log("Overriding frog singeleton");
            Destroy(Singleton);
            Singleton = this;
        }

        Singleton = this;
    }

    void Start()
    {
        _playerManager = FindObjectOfType<PlayerManager>();
        _runner = _playerManager.Runner;
        _runner.RunnerPlayerInput.PlayerMoved += OnPlayerMoved;
        _spawner = FindObjectOfType<FrogSpawner>();
    }


    private void OnDestroy()
    {
        if(_runner is null)
            return;
        
        _runner.RunnerPlayerInput.PlayerMoved -= OnPlayerMoved;
    }

    private void Update()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.4f, layerMask);
        if(colliders.Length < 1)
        {
            TakeDamage(); 
        }
        else
        {
            foreach (var collider in colliders)
            {
                var platform = collider.GetComponent<Platform>();

                if (platform is null) continue;
                else
                {
                    transform.SetParent(platform.transform);
                    return;
                }
            }

            transform.SetParent(null);
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
        var delta = vector.normalized * jumpLength;
        transform.position += (Vector3)delta;
        FrogMoved?.Invoke();
    }
    
    public void TakeDamage()
    {
        Kill();
    }

    private void Kill()
    {
        FromKilled?.Invoke();
        Remove();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.4f);
    }

    public void Remove()
    {
        FromRemoved?.Invoke();

        transform.position = _spawner.GetSpawnPoint();
    }
}