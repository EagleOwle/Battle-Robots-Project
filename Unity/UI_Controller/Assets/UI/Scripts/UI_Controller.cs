using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MainMenuState
{
    MainMenu,
    InGameMenu,
    PreferenceMenu,
    ActionMenu,
    GraphicMenu,
    AudioMenu,
    InputMenu,
    KeyBindingMenu,
    MouseBindingMenu,
    Exit,
    
}

public enum UiSoundEffect
{
    Enter,
    Up,
    None,
}

public class UI_Controller : MonoBehaviour
{
    private static UI_Controller _singleton;

    public static UI_Controller Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = GameObject.FindObjectOfType<UI_Controller>();
            }

            return _singleton;
        }
    }

    [Header("Цвета меню")]
    [Tooltip("Массив 0=normal, 1=highlighted, 2=pressed, 3=disabled, 4=alarm")]
    public Color[] colorArray;

    [Header("Звуки меню")]
    public AudioClip[] ui_sound;

    private void Start()
    {
        ChangeState(0);
        //InputManager.Singleton.Delegate_KeyPress += GetKeyPress;
    }

    private void OnDestroy()
    {
        //InputManager.Singleton.Delegate_KeyPress -= GetKeyPress;
    }

    public void GetKeyPress(GameKey inputKey)
    {
        if (inputKey == GameKey.Cancel)
        {
            UI_Controller.Singleton.ChangeState(0);//MainMenu
        }
    }

    public void ChangeState(int nextState = 0)
    {
        
        /*
        if (currentMenuState == MainMenuState.InGameMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        */
    }

    public void ShowDebugMessage(string message)
    {
        UI_DebugMessage.Instance.ShowNewMessage(message);
    }

    public void PlaySound(UiSoundEffect clip)
    {
        GetComponent<AudioSource>().PlayOneShot(ui_sound[(int)clip]);
    }

    void QuitApplication()
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
