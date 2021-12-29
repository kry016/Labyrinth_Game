using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    [SerializeField] private ModeInput modeInput;
    [SerializeField] private bool debug;

    public void ToggleBar()
    {
        GestorInput();
    }

    private void GestorInput()
    {
        switch (modeInput)
        {
            case ModeInput.Gyroscope:
                Input(true, false);
                break;
            case ModeInput.Touch:
                Input(false, true);
                break;
        }
    }

    private void Input(bool gyro, bool touch)
    {
        InputManager.inputGyro = gyro;
        InputManager.inputTouch = touch;
    }

    void OnGUI()
    {
        if (debug)
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = Mathf.RoundToInt(Mathf.Min(Screen.width, Screen.height) / 20f);
            style.normal.textColor = Color.white;
            GUILayout.BeginVertical("box");
            GUILayout.Label("InputTouch: " + InputManager.inputTouch.ToString(), style);
            GUILayout.Label("InputGyro: " + InputManager.inputGyro.ToString(), style);
            GUILayout.EndVertical();
        }
    }
}

[System.Serializable]

public enum ModeInput
{
    Touch,
    Gyroscope
}