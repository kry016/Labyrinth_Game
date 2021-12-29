using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject Menu, Option;
    public static UIManagerScript uiManager;
    void Awake()
    {
        if (!uiManager) uiManager = this;
        UISelect(true, false);
    }

    public void UISelect(bool menu, bool option)
    {
        if (Menu && Option)
        {
            Menu.SetActive(menu);
            Option.SetActive(option);
        }
 
    }
}
