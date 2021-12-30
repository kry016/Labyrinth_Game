using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public void EndAnimation()
    {

        InputManager.Paused = false;
        UIManagerScript.uiManager.UISelect(false, false, true, false, false, false);
        gameObject.GetComponent<Animator>().SetBool("Revers", false);               
    }
}
