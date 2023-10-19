using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShooterPlayerInput : MonoBehaviour
{
    public event Action<Vector2> PlayerMoved;
    public event Action PlayerShot;
    public event Action<Vector2> PlayerReload;

    public void Move(InputAction.CallbackContext context)
    {
        var move = context.ReadValue<Vector2>();
        PlayerMoved?.Invoke(move);
    }

    public void Shot(InputAction.CallbackContext callbackContext)
    {
        if(!callbackContext.performed)
            return;

        PlayerShot?.Invoke();
    }

    public void Reload(InputAction.CallbackContext context)
    {
        var move = context.ReadValue<Vector2>();
        PlayerReload?.Invoke(move);
    }
}
