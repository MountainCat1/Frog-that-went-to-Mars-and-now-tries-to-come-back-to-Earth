using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CommonPlayerInput : MonoBehaviour
{
    public event Action OnReady;
    public event Action OnNotReady;

    public void Ready(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            OnReady?.Invoke();
        else if (callbackContext.canceled)
            OnNotReady?.Invoke();
            
    }
}