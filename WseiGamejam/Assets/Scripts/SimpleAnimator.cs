using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimator : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int _currentFrameIndex = 0;
    private AnimatorManager _animatorManager;

    private void Start()
    {
        _animatorManager = FindObjectOfType<AnimatorManager>();
        _animatorManager.NewFrame += OnNewFrame;
        spriteRenderer.sprite = frames[0];
    }

    private void OnDestroy()
    {
        _animatorManager.NewFrame -= OnNewFrame;
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
