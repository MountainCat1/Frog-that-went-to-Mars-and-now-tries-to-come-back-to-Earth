using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatorManager : MonoBehaviour
{
    public event Action NewFrame; 

    private float _framesPerSecond;

    private void Awake()
    {
        _framesPerSecond = ConstValues.FramesPerSecond;
    }
    
    private IEnumerator AnimationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / _framesPerSecond);
            NewFrame?.Invoke();
        }
    }
}