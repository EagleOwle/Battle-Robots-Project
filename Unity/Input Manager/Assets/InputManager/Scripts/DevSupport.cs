using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSupport : MonoBehaviour
{
    public Vector3 direction = Vector3.zero;
    public string useKey;

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
        useKey = inputKey.ToString();
    }
}
