using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRebind : MonoBehaviour
{
    private static KeyRebind _singleton;

    public static KeyRebind Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = GameObject.FindObjectOfType<KeyRebind>();
            }

            return _singleton;
        }
    }

    [Tooltip("ССылка на класс контролирующий нажатие кнопки")]
    public GameInputKey currentKeyBinding;
    [Tooltip("Обьект выводит сообщение о том, что кнопка уже используется")]
    public GameObject confirmChangesObj;
    [Tooltip("Текущая кнопка, которую нажал пользователь")]
    private KeyCode newKey;
    [Tooltip("Флаг включает проверку на нажатие кнопки пользователем")]
    private bool waitPressKey;

    Event curEvent;

    private void OnEnable()
    {
        waitPressKey = true;
        confirmChangesObj.SetActive(false);
    }

    private void OnGUI()
    {
        curEvent = Event.current;

        if (curEvent.isKey && curEvent.type == EventType.keyUp)
        {
            newKey = curEvent.keyCode;
            waitPressKey = false;
            CheckNewKey(newKey);
        }
    }

    private void CheckNewKey(KeyCode key)
    {
        //Если текущая кнопка входит в состав массива keyboardKeyArray
        if (Array.IndexOf(InputManager.Singleton.keyboardKeyArray, key) == -1)
        {
            if (key == KeyCode.Escape)
            {
                CancelChange();
                return;
            }
            else
            {
                confirmChangesObj.SetActive(true);
                return;
            }
        }
        else
        {
            //Проверяем все классы KeyBinding
            foreach (GameInputKey keyBindings in GameObject.FindObjectsOfType<GameInputKey>())
            {
                //Если в проверяемом классе KeyBinding уже используется такая кнопка 
                //и этот класс не является текущим  currentKeyBinding
                if (keyBindings.keyKode == key && keyBindings != currentKeyBinding)
                {
                    confirmChangesObj.SetActive(true);
                    return;
                }
            }
        }

        SetNewKey();
    }

    private void SetNewKey()
    {
        currentKeyBinding.SetNewKey(newKey);
        confirmChangesObj.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ConfirmChange()
    {
        //Проверяем все классы KeyBinding
        foreach (GameInputKey AllKey in InputManager.Singleton.keyBinding)
        {
            if (AllKey.keyKode == newKey)//если кнопка в классе KeyBinding такая же, что и текущая назначенная
            {
                AllKey.SetNewKey();//Удаляем кнопку назначенную в KeyBinding
                currentKeyBinding.SetNewKey(newKey);//В текущем KeyBinding назначаем новую кнопку
                confirmChangesObj.SetActive(false);
                gameObject.SetActive(false);
                return;
            }
        }
    }

    public void CancelChange()
    {
        currentKeyBinding.SetNewKey(currentKeyBinding.keyKode);
        confirmChangesObj.SetActive(false);
        gameObject.SetActive(false);
    }

    public void AddChange()
    {
        currentKeyBinding.SetNewKey(newKey);
        confirmChangesObj.SetActive(false);
        gameObject.SetActive(false);
    }
}
