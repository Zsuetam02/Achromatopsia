using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class StateMachine : MonoBehaviour
{
    public static StateMachine Instance { get; private set; }
    public static event Action<GameState> OnStateChanged;

    public enum GameState
    {
        All,
        Protanopia, 
        Deuteranopia,
        Tritanopia,
        Protanomaly,
        Deuteranomaly,
        Tritanomaly,
        Monochromacy
    }

    public GameState currentState;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    void Start()
    {
        ChangeState(GameSettings.SelectedGameState);
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;
        OnStateChanged?.Invoke(newState);
    }


  


}