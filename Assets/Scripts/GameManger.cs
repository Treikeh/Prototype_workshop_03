using System;
using UnityEngine;

public static class GameManager
{
    public static Action gameOver;
    public static Action playerHit;
    public static Action enemyKilled;

    public enum GameStates {Start, Active, End}
    public static GameStates gameState = GameStates.Start;
    public static int score = 0;


    public static void StartGame()
    {
        gameState = GameStates.Active;
    }

    public static void EndGame()
    {
        gameState = GameStates.End;
        gameOver?.Invoke();
    }

    public static void ResetGame()
    {
        gameState = GameStates.Start;
        score = 0;
    }

    public static void EnemyKilled(int val)
    {
        score += val;
        enemyKilled?.Invoke();
    }
}
