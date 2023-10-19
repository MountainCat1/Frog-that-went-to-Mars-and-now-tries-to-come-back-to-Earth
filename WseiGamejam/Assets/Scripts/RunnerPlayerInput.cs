using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RunnerPlayerInput : MonoBehaviour
{
    public event Action<Vector2> PlayerMoved;

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed == false) return;

        var move = context.ReadValue<Vector2>();
        PlayerMoved?.Invoke(move);
    }
}
