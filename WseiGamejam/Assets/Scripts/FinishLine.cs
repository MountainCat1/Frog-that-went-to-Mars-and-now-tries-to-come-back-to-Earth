using System;
using UnityEngine;
using Zenject;

public class FinishLine : MonoBehaviour
{
    public event Action FrogEscaped;
    
    [SerializeField] private float finishY = 14f; 
    
    private void Start()
    {
        Frog.FrogMoved += OnFrogMoved;
    }

    private void OnFrogMoved()
    {
        if (Frog.Singleton.transform.position.y > finishY)
        {
            FrogEscaped?.Invoke();
        }
    }
}