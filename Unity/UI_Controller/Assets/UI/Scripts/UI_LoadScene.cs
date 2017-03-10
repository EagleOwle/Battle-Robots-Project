using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LoadScene : MonoBehaviour
{
    public int nextLevel;

    private void OnEnable()
    {
        LoadLevel(nextLevel);
    }

    private void LoadLevel(int value)
    {
        if (value >= Application.levelCount)
        {
            UI_DebugMessage.Singleton.ShowNewMessage("No this value level. Add level to build setting", 3);
            Debug.Log("No this value level");
            return;
        }

            if (value != Application.loadedLevel)
        {
            Application.LoadLevel(value);
        }
    }
}
