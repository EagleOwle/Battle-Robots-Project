using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InGameMenu : MonoBehaviour {

    private void OnEnable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
