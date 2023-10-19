using UnityEngine;

public class Trap : MonoBehaviour
{
    private Vector2 _destination;
    private float _speed;

    public void Initialize(Vector3 destination, float speed = 1f)
    {
        _speed = speed;
        _destination = destination;
    }

    private void Update()
    {
        float step = Time.deltaTime * _speed;
        transform.position = Vector2.MoveTowards(transform.position, _destination, step);
        
        
        if(Vector2.Distance(transform.position, _destination) <= 0.01f)
            Destroy(gameObject);
    }
}
