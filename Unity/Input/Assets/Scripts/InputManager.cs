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
    None,
}

public delegate int KeyPress(GameKey inputKey);


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
    };

    public List<GameInputKey> keyBinding;
    public KeyPress Delegate_KeyPress;

    public void CheckUsedKey()
    {
        for (int i = 0; i < keyBinding.Count; i++)
        {
            keyBinding[i].nameCurrentKey.color = Color.black;

            foreach (GameInputKey keyBindings in keyBinding)
            {
                if (keyBindings != keyBinding[i])
                {
                    if (keyBindings.keyKode == keyBinding[i].keyKode)
                    {
                        keyBinding[i].nameCurrentKey.color = Color.red;
                    }
                }
            }
        }
    }

    private void Start()
    {
        Delegate_KeyPress += GetKeyPress;
    }

    public int GetKeyPress(GameKey inputKey)
    {
        Debug.Log(inputKey);
        return 0;
    }

    private void Update()
    {
        foreach (GameInputKey inputKey in keyBinding)
        {
            if (Input.GetKey(inputKey.keyKode) == true)
            {
                Delegate_KeyPress(inputKey.gameKey);
            }
        }
    }
}
