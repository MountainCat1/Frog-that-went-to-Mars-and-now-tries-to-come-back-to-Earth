using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SoundShitter : MonoBehaviour
{
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip jumpSound;

    public SoundShitter Singeleton { get; set; }

    private void Awake()
    {
        if (Singeleton != null)
        {
            Destroy(this);
            return;
        }

        Singeleton = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (Singeleton != this)
            return;
        
        
        Scope.Shot += () => AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
        Frog.FromKilled += () => AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        Scope.Reloaded += () => AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
        // Frog.FrogMoved += () => AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
    }
}