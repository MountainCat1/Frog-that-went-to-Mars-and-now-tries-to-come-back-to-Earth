using UnityEngine;
using UnityEngine.InputSystem;

public class Scope : MonoBehaviour
{
    [SerializeField]
    public float InputStrength = 7f;

    [SerializeField]
    private GameObject Bullet;

    private Vector3 currentMovement;

    public void Init(ShooterPlayerInput shooterPlayerInput)
    {
        shooterPlayerInput.PlayerMoved += OnPlayerMoved;
        shooterPlayerInput.PlayerShot += OnPlayerShot;
    }

    public void Update()
    {
        transform.position += currentMovement * Time.deltaTime * InputStrength;
    }

    private void OnPlayerMoved(Vector2 obj)
    {
        currentMovement = new Vector3(obj.x, obj.y, 0f);
    }

    private void OnPlayerShot()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity);
    }
}
