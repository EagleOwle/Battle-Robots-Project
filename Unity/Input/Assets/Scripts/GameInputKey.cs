using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInputKey : MonoBehaviour
{
    [Header("Состояние, в котором обрабатывается нажатие")]
    public KeyStatus keyStatus;
    [Header("Что выполняет данная кнопка")]
    public GameKey gameKey;
    [Header("Текущая назначенная кнопка")]
    public KeyCode keyKode = KeyCode.None;
    [Header("Компонент Text, имя текущей кнопки")]
    public Text nameCurrentKey;
    [Header("Компонент Text, имя, что выполняет данная кнопка")]
    public Text targetKeyText;

    public bool changedKey = true;

    private void OnEnable()
    {
        KeyRebind.Singleton.gameObject.SetActive(false);

        if (changedKey == true)
        {
            targetKeyText.text = gameKey.ToString();
            SetNewKey(keyKode);
        }
    }

    public void WaitPressKey(Text text)
    {
        text.text = "Press any key";
        KeyRebind.Singleton.gameObject.SetActive(true);
        KeyRebind.Singleton.currentKeyBinding = this;
    }

    public void SetNewKey(KeyCode newKey = KeyCode.None)
    {
        keyKode = newKey;

        if (changedKey == true)
        {
            nameCurrentKey.text = keyKode.ToString();
        }
        
        InputManager.Singleton.CheckUsedKey();
    }

    /*
    private void CheckForUse()
    {
        foreach (GameInputKey keyBindings in InputManager.Singleton.keyBinding)
        {
            if (keyBindings != this)
            {
                if (keyBindings.keyKode == keyKode)
                {
                    nameCurrentKey.color = Color.red;
                    keyBindings.nameCurrentKey.color = Color.red;
                    return;
                }
            }
        }

        nameCurrentKey.color = Color.black;
    }
    */
    
}
