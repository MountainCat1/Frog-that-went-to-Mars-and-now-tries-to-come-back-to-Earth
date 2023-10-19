using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public event Action PlayerReady;
    public event Action PlayerNotReady;
    
    [field: SerializeField] public PlayerInput Input { get; set; }
    [field: SerializeField] public CommonPlayerInput CommonInput { get; set; }
    [field: SerializeField] public RunnerPlayerInput RunnerPlayerInput { get; set; }
    [field: SerializeField] public ShooterPlayerInput ShooterPlayerInput { get; set; }
    
    public bool Ready { get; set; }
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(this);
    }
    private void Start()
    {
        CommonInput.OnReady += OnInputReady;
        CommonInput.OnNotReady += OnInputNotReady;
    }

    private void OnInputReady()
    {
        Ready = true;
        PlayerReady?.Invoke();
    }
    private void OnInputNotReady()
    {
        Ready = false;
        PlayerNotReady?.Invoke();
    }
    
    
}