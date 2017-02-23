using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameKey
{
    Forward, 
    Backward,
    Left,
    Right,
    Up,
    Down,
    Action,
    Shoot,
    Pricel,
    None,
    Cancel,
}

public enum KeyStatus
{
    On,
    Up,
    Down,
}

public enum SpetialKey
{
    Cancel,
    Enter,
    None,
}

public delegate void KeyPress(GameKey inputKey);


public class InputManager : MonoBehaviour
{
    private static InputManager _singleton;

    public static InputManager Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = GameObject.FindObjectOfType<InputManager>();
            }

            return _singleton;
        }
    }

    [Header("Разрешённые кнопки клавиатуры")]
    public KeyCode[] keyboardKeyArray = new KeyCode[] 
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R,
        KeyCode.T,
        KeyCode.Y,
        KeyCode.U,
        KeyCode.I,
        KeyCode.O,
        KeyCode.P,
        KeyCode.A,
        KeyCode.S,
        KeyCode.D,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.Z,
        KeyCode.X,
        KeyCode.C,
        KeyCode.V,
        KeyCode.B,
        KeyCode.N,
        KeyCode.M,
        KeyCode.LeftAlt,
        KeyCode.RightAlt,
        KeyCode.LeftShift,
        KeyCode.RightShift,
        KeyCode.LeftControl,
        KeyCode.RightControl,
        KeyCode.Space,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.Backspace,
        KeyCode.Mouse0,
        KeyCode.Mouse1,
        KeyCode.Mouse2,
        KeyCode.None,
    };

    [Header("Классы отвечающие за каждую кнопку")]
    [Tooltip("Сюда нужно добавить все классы GameInputKey")]
    public GameInputKey[] gameInputKey;

    public KeyPress Delegate_KeyPress;

    public void CheckUsedKey()
    {
        for (int i = 0; i < gameInputKey.Length; i++)
        {
            if (gameInputKey[i].changedKey == true)
            {
                gameInputKey[i].SetAlarmColor(UI_Controller.Singleton.colorArray[1]);

                foreach (GameInputKey keyBindings in gameInputKey)
                {
                    if (keyBindings != gameInputKey[i])
                    {
                        if (keyBindings.keyKode == gameInputKey[i].keyKode)
                        {
                            gameInputKey[i].SetAlarmColor(UI_Controller.Singleton.colorArray[5]);
                        }
                    }
                }
            }
        }
    }

    private void Update()
    {
        foreach (GameInputKey inputKey in gameInputKey)
        {
            if (inputKey.keyStatus == KeyStatus.On)
            {
                if (Input.GetKey(inputKey.keyKode) == true)
                {
                    Delegate_KeyPress(inputKey.gameKey);
                }
            }

            if (inputKey.keyStatus == KeyStatus.Down)
            {
                if (Input.GetKeyDown(inputKey.keyKode) == true)
                {
                    Delegate_KeyPress(inputKey.gameKey);
                }
            }

            if (inputKey.keyStatus == KeyStatus.Up)
            {
                if (Input.GetKeyUp(inputKey.keyKode) == true)
                {
                    Delegate_KeyPress(inputKey.gameKey);
                }
            }
        }
    }
}
