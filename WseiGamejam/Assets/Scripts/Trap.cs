using System;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Vector2 _destination;
    private float _speed;
    private float _acceleration;

    public void Initialize(Vector3 destination, float speed = 1f, float acceleration = 1f)
    {
        _acceleration = acceleration;
        _speed = speed;
        _destination = destination;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var frog = col.gameObject.GetComponent<Frog>();
        if(frog is null)
            return;
        
        frog.TakeDamage();
    }

    private void Update()
    {
        _speed += _acceleration * Time.deltaTime;
        
        
        float step = Time.deltaTime * _speed;
        transform.position = Vector2.MoveTowards(transform.position, _destination, step);
        
        
        if(Vector2.Distance(transform.position, _destination) <= 0.01f)
            Destroy(gameObject);
    }
}
