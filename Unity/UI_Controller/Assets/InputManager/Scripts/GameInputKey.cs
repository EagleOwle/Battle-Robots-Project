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
    [Header("Компонент GameObject, имя текущей кнопки")]
    public GameObject nameCurrentKey;
    [Header("Компонент Text, имя, что выполняет данная кнопка")]
    public Text targetKeyText;
    public Image AlarmImage;
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

    public void SetNewKey(KeyCode newKey)
    {
        keyKode = newKey;
        nameCurrentKey.GetComponent<UI_ElementButton>().SetNewMessage(newKey.ToString());
        SetAlarmColor(UI_Controller.Singleton.colorArray[0]);
        InputManager.Singleton.CheckUsedKey();
    }

    public void SetAlarmColor(Color newColor)
    {
        AlarmImage.color = newColor;
    }
}
