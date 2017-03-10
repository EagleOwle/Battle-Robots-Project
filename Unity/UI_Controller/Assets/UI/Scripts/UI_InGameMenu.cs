using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InGameMenu : MonoBehaviour
{

    [Header("Previouse menu")]
    [SerializeField]
    UI_MenuChanger menuChanger;

    [SerializeField]
    int ActionMenuIndex;

    private void OnEnable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InputManager.Singleton.Delegate_KeyPress += GetKeyPress;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        InputManager.Singleton.Delegate_KeyPress -= GetKeyPress;
    }

    private void OnDestroy()
    {
        InputManager.Singleton.Delegate_KeyPress -= GetKeyPress;
    }

    public void GetKeyPress(GameKey inputKey)
    {
        if (inputKey == GameKey.Action)
        {
            menuChanger.KeyCancel(ActionMenuIndex);
        }
    }
}
