using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : UI_MenuControllerAbstract
{
    private void Start()
    {
        ChangeMenu(0);
    }

    public override void CancelKey()
    {
        ChangeMenu(3);
    }

    public void ExitAplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }
}
