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

    public KeyBinding currentKeyBinding;
    public GameObject confirmChangesObj;

    private KeyCode newKey;
    private bool waitPressKey;

    private Event curEvent;
    private Array keyboardKeyArray;

    //Debug
    public int index;
    //EndDebug

    private void OnEnable()
    {
        waitPressKey = true;
        confirmChangesObj.SetActive(false);

        keyboardKeyArray = Enum.GetValues(typeof(KeyboardKey));

        //Debug
        index = 0;
        //EndDebug
    }

    //Debug
    /*
    private void Update()
    {
        if (index >= 0)
        {
            if (index < keyboardKeyArray.Length)
            {
                Debug.Log(keyboardKeyArray.GetValue(index));
                index++;
            }
            else
            {
                Debug.Log("EndArray " + index);
                index = -1;
            }
        }
    }
    */
    //EndDebug


    private void OnGUI()
    {
        curEvent = Event.current;

        if (curEvent.isKey && curEvent.type == EventType.KeyUp)
        {
            newKey = curEvent.keyCode;
            waitPressKey = false;

            if (CheckNewKey(newKey) == true)
            {
                currentKeyBinding.SetNewKey(newKey);
                confirmChangesObj.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                confirmChangesObj.SetActive(true);
            }
        }
    }

    private bool CheckNewKey(KeyCode key)
    {
        foreach (KeyBinding keyBindings in GameObject.FindObjectsOfType<KeyBinding>())
        {
            if (keyBindings.useKeyKode == key && keyBindings != currentKeyBinding)
            {
                return false;
            }
        }

        if (Array.IndexOf(InputManager.Singleton.canUseKeys, key) != -1)
        {
            return true;
        }
        else
        {
            Debug.Log("... key " + key + " is not supported");
            return false;
        }
    }

    public void ConfirmChange()
    {
        foreach (KeyBinding AllKey in GameObject.FindObjectsOfType<KeyBinding>())
        {
            if (AllKey.useKeyKode == newKey)
            {
                AllKey.ClearKey();
                currentKeyBinding.SetNewKey(newKey);
                confirmChangesObj.SetActive(false);
                gameObject.SetActive(false);
                return;
            }
        }
    }

    public void CancelChange()
    {
        currentKeyBinding.SetKey();
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
