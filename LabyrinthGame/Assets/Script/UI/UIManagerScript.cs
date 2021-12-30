using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private StartMenu startMenu;
    [SerializeField] private GameMenu gameMenu;
    [SerializeField] private Image[] starGame;
    public static UIManagerScript uiManager;
    void Awake()
    {
        if (!uiManager) uiManager = this;
        UISelect(true, false, true, false, false, false);
    }

    public void UISelect(bool menu, bool option, bool interfaceGame, bool optionGame, bool victoryGame, bool loseGame)
    {
        if (startMenu.Menu) startMenu.Menu.SetActive(menu);
        if (startMenu.Option) startMenu.Option.SetActive(option);
        if(gameMenu.InterfaceGame) gameMenu.InterfaceGame.SetActive(interfaceGame);
        if (gameMenu.OptionGame) gameMenu.OptionGame.SetActive(optionGame);
        if (gameMenu.VictoryGame) gameMenu.VictoryGame.SetActive(victoryGame);
        if (gameMenu.LoseGame) gameMenu.LoseGame.SetActive(loseGame);

    }

    public void PointsFinal()
    {
        for (int i = 0; GameManager.star > i; i++)
        {
            starGame[i].color = new Color(255, 255, 255);
        }
    }
}

[System.Serializable]

public struct StartMenu
{
    public GameObject Menu;
    public GameObject Option;
}

[System.Serializable]
public struct GameMenu
{
    public GameObject InterfaceGame;
    public GameObject OptionGame;
    public GameObject VictoryGame;
    public GameObject LoseGame;

}

