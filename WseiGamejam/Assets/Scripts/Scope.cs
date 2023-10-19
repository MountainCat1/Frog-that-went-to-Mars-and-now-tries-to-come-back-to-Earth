using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    [SerializeField]
    public float InputStrength = 2f;

    [SerializeField]
    private float BulletRadius = 0.12f;

    private Rigidbody2D rb;

    private Vector2 currentMovement;

    public void Init(ShooterPlayerInput shooterPlayerInput)
    {
        shooterPlayerInput.PlayerMoved += OnPlayerMoved;
        shooterPlayerInput.PlayerShot += OnPlayerShot;
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rb.AddForce((currentMovement * Time.deltaTime * InputStrength));
        //transform.position += currentMovement * Time.deltaTime * InputStrength;
    }

    private void OnPlayerMoved(Vector2 obj)
    {
        currentMovement = new Vector2(obj.x, obj.y);
    }

    private void OnPlayerShot()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, BulletRadius);
        Debug.DrawLine(transform.position + Vector3.left * BulletRadius, transform.position + Vector3.right * BulletRadius);

        foreach(var collider in colliders)
        {
            var buff = collider.GetComponent<BuffPickup>();
            if(buff != null)
            {
                Debug.Log(buff.test);
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
