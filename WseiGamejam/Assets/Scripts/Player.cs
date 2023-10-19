using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public event Action OnPlayerReady;
    public event Action OnPlayerNotReady;
    
    [field: SerializeField] public PlayerInput Input { get; set; }
    [field: SerializeField] public CommonPlayerInput CommonInput { get; set; }
    
    public bool Ready { get; set; }

    private void Start()
    {
        CommonInput.OnReady += OnInputReady;
        CommonInput.OnNotReady += OnInputNotReady;
    }

    private void OnInputReady()
    {
        Ready = true;
        OnPlayerReady?.Invoke();
    }
    private void OnInputNotReady()
    {
        Ready = false;
        OnPlayerNotReady?.Invoke();
    }
    
    
}