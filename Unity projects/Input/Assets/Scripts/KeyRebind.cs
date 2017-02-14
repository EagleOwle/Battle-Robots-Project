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

    Event curEvent;

    private void OnEnable()
    {
        waitPressKey = true;
        confirmChangesObj.SetActive(false);
    }

    private void OnGUI()
    {
        curEvent = Event.current;

        if (curEvent.isKey && curEvent.keyCode != KeyCode.None)
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

        //KeyboardKey tempstring = (KeyboardKey)Enum.Parse(typeof(KeyboardKey), "_");

        /*
        for (int i = 0; i< (int)KeyboardKey.None; i++)
        {
            if ((int)key == i)
            {
                Debug.Log("key= " + (int)key);
                Debug.Log("i= " + i);
                return true;
            }
        }
        */
        return true;
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
