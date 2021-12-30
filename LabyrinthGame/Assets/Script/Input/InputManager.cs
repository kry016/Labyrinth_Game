using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool inputGyro = true;
    public static bool inputTouch;
    public static bool Paused;

    public static void Pause(GameObject Input)
    {
        Input.GetComponent<GyroscopeSystem>().currentRotation = Input.transform.rotation;
        Input.GetComponent<JoyStick>().currentRotation = Input.transform.rotation;
    }
}
