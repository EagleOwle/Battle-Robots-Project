﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelfMenu : MonoBehaviour
{
    public UI_MenuChanger menuChanger;

    public int GoBackIndex;

    private void OnEnable()
    {
        InputManager.Singleton.Delegate_KeyPress += GetKeyPress;
    }

    private void OnDisable()
    {
        InputManager.Singleton.Delegate_KeyPress -= GetKeyPress;
    }

    private void OnDestroy()
    {
        InputManager.Singleton.Delegate_KeyPress -= GetKeyPress;
    }

    public void GetKeyPress(GameKey inputKey)
    {
        if (inputKey == GameKey.Cancel)
        {
            menuChanger.KeyCancel(GoBackIndex);
        }
    }

}
