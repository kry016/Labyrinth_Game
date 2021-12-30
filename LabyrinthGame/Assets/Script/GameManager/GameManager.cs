using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int star;

    public static void AddStarPoint()
    {
        star++;
    }

    public static void VictoryGame(GameObject boardGame)
    {
        InputManager.Paused = true;
        InputManager.Pause(boardGame);
        UIManagerScript.uiManager.UISelect(false, false, true, false, true, false);
        UIManagerScript.uiManager.PointsFinal();
    }

    public static void LoserGame(GameObject boardGame)
    {
        InputManager.Paused = true;
        InputManager.Pause(boardGame);
        UIManagerScript.uiManager.UISelect(false, false, true, false, false, true);
    }
}
