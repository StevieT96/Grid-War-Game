using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        instance = this;
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.SelectPlayer:
                HandleSelectPlayer();
                break;
            case GameState.GenerateGrid:
                break;
            case GameState.SpawnUnitsP1:
                break;
            case GameState.SpawnUnitsP2:
                break;
            case GameState.Player1Turn:
                break;
            case GameState.Player2Turn:
                break;
            case GameState.Player1Victory:
                break;
            case GameState.Player2Victory:
                break;
                default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }
    private void HandleSelectPlayer()
    {
        throw new NotImplementedException();   
    }
}

public enum GameState
{
    SelectPlayer,
    GenerateGrid,
    SpawnUnitsP1,
    SpawnUnitsP2,
    Player1Turn,
        Player2Turn,
        Player1Victory,
        Player2Victory,
       
}