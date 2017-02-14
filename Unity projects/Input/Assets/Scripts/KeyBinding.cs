using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBinding : MonoBehaviour
{
    public TargetKey targetKey;
    public KeyCode useKeyKode = KeyCode.None;

    public Text nameKey;
    public Text targetKeyText;

    private void OnEnable()
    {
        KeyRebind.Singleton.gameObject.SetActive(false);
        targetKeyText.text = targetKey.ToString();
        SetKey();
    }

    public void SetKey()
    {
        nameKey.text = useKeyKode.ToString();
    }

    public void WaitPressKey(Text text)
    {
        text.text = "Press any key";
        KeyRebind.Singleton.gameObject.SetActive(true);
        KeyRebind.Singleton.currentKeyBinding = this;
    }

    public void ClearKey()
    {
        useKeyKode = KeyCode.None;
        nameKey.text = useKeyKode.ToString();
    }

    public void SetNewKey(KeyCode newKey)
    {
        useKeyKode = newKey;
        nameKey.text = newKey.ToString();
    }
}
