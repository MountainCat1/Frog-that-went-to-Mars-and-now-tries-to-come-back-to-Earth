using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimator : MonoBehaviour
{
    [SerializeField] private List<Sprite> frames;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float _framesPerSecond;

    private void Awake()
    {
        _framesPerSecond = ConstValues.FramesPerSecond;
    }

    private void Start()
    {
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
        var currentFrameIndex = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f / _framesPerSecond);
            currentFrameIndex++;
            if (currentFrameIndex >= frames.Count)
                currentFrameIndex = 0;
            spriteRenderer.sprite = frames[currentFrameIndex];
        }
    }
}
