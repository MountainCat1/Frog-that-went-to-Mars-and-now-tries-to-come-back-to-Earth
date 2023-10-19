using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Scope : MonoBehaviour
{
    [SerializeField]
    public float InputStrength = 2f;

    [SerializeField]
    private float BulletRadius = 0.12f;

    [Inject]
    private ShooterPlayerInput shooterPlayerInput;
    
    private Rigidbody2D rb;

    private Vector2 currentMovement;

    private bool canFire = true;

    private static Vector2[] reloadZones = new Vector2[] { new Vector2(0f, 1f), new Vector2(-1f, 0f), new Vector2(0f, -1f), new Vector2(1f, 0f) };
    float realoadZonesErrorTolerance = 0.1f;
    int index = 0;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        shooterPlayerInput.PlayerMoved += OnPlayerMoved;
        shooterPlayerInput.PlayerShot += OnPlayerShot;
    }

    public void Update()
    {
        rb.AddForce(currentMovement * Time.deltaTime * InputStrength);
        //transform.position += currentMovement * Time.deltaTime * InputStrength;
    }

    private void OnPlayerMoved(Vector2 obj)
    {
        currentMovement = new Vector2(obj.x, obj.y);

        if (NearlyEqual(obj, reloadZones[index], realoadZonesErrorTolerance))
        {
            if(index == 0)
            {
                StartCoroutine("ResetReload");
            }

            if (++index == reloadZones.Length)
            {
                canFire = true;
                index = 0;
            }
        }
    }

    private IEnumerator ResetReload()
    {
        yield return new WaitForSeconds(1.2f);
        index = 0;
    }

    public static bool NearlyEqual(Vector2 a, Vector2 b, float error = 0.1f)
    {
        return a.x - b.x <= error && a.y - b.y <= error;
    }

    private void OnPlayerShot()
    {
        if (!canFire) return;
        Debug.Log("Shot");
        canFire = false;

        var colliders = Physics2D.OverlapCircleAll(transform.position, BulletRadius);
        Debug.DrawLine(transform.position + Vector3.left * BulletRadius, transform.position + Vector3.right * BulletRadius);

        foreach(var collider in colliders)
        {
            var buff = collider.GetComponent<BuffPickup>();
            if(buff != null)
            {

            }
        }

        //Instantiate(Bullet, transform.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, BulletRadius);
    }
}
