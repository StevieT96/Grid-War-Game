using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState State;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }
    public void ChangeState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.SelectPlayer:
                HandleSelectPlayer();
                break;
            case GameState.GenerateGrid:
                GridManager.instance.GenerateGrid();
                break;
            case GameState.SpawnUnitsP1:
                UnitManager.instance.SpawnUnitFaction1();
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
    
    }
    private void HandleSelectPlayer()
    {
        throw new NotImplementedException();   
    }
}

public enum GameState
{
    SelectPlayer = 0,
    GenerateGrid = 1,
    SpawnUnitsP1 = 2,
    SpawnUnitsP2 = 3,
    Player1Turn = 4,
        Player2Turn = 5,
        Player1Victory,
        Player2Victory,
       
}