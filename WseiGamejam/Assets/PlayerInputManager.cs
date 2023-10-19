using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> PlayerMoved;
    public event Action PlayerShot;

    public void Start()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        var move = context.ReadValue<Vector2>();
        PlayerMoved?.Invoke(move);
    }

    public void Shot(InputAction.CallbackContext callbackContext)
    {
        if(!callbackContext.performed)
            return;

        Debug.Log("XD");
        PlayerShot?.Invoke();
    }
}
