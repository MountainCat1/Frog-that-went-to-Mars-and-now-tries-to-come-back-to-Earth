using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimator : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int _currentFrameIndex = 0;

    private void Start()
    {
        var animationManager = FindObjectOfType<AnimatorManager>();
        animationManager.NewFrame += OnNewFrame;
        spriteRenderer.sprite = frames[0];
    }

    private void OnNewFrame()
    {
        if (frames.Count <= 1)
            return;
        
        _currentFrameIndex++;
        if (_currentFrameIndex >= frames.Count)
            _currentFrameIndex = 0;
        spriteRenderer.sprite = frames[_currentFrameIndex];
    }
}
