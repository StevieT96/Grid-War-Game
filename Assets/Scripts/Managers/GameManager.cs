using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState GameState;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }
    //will add multiplayer components to the game manager over the week
    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.instance.GenerateGrid();
                break;
            case GameState.SpawnFaction1:
                UnitManager.instance.SpawnFaction1();
                break;
            case GameState.SpawnFaction2:
                UnitManager.instance.SpawnFaction2();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.Player2Turn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnFaction1 = 1,
    SpawnFaction2 = 2,
    PlayerTurn = 3,
    Player2Turn = 4
}