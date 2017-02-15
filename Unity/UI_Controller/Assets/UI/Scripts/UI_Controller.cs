using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MenuState
{
    MainMenu,
    InGameMenu,
    PreferenceMenu,
    ActionMenu,
    GraphicMenu,
    AudioMenu,
    inputMenu,
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
    public static UI_Controller Instance { get; private set; }

    [Header("Состояние меню")]
    public  MenuState menuState;
    [Tooltip("Тукущее состояние меню")]
    private MenuState currentMenuState;
    [Header("Список элементов меню")]
    public Transform[] menuArray;

    [Header("Цвета меню")]
    [Tooltip("Массив 0=normal, 1=highlighted, 2=pressed, 3=disabled, 4=alarm")]
    public Color[] colorArray;

    [Header("Звуки меню")]
    public AudioClip[] ui_sound;

    [Tooltip("Текущее меню")]
    private Transform currentMenu;

    [Tooltip("Текущее меню")]
    public bool inGame = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(0);
    }

    private void Update()
    {
        GetEscButton();
        //Debug
        ChangeState(-1);
        //EndDebug
        
    }

    private void  GetEscButton()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            UI_Controller.Instance.ChangeState(0);//MainMenu
        }
    }

    public void ChangeState(int nextState = 0)
    {
        if (nextState == -1)
        {
            if (currentMenuState == menuState)
            {
                return;
            }
        }
        else
        {
            menuState = (MenuState)nextState;
            currentMenuState = menuState;
        }

        ChangeMenu((int)currentMenuState);

        //Выход из приложения
        if (currentMenuState == MenuState.Exit)
        {
            QuitApplication();
        }

        if (currentMenuState == MenuState.InGameMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ShowDebugMessage(string message)
    {
        //UI_DebugMessage.Instance.message = message;
        UI_DebugMessage.Instance.ShowNewMessage(message);
    }

    public void PlaySound(UiSoundEffect clip)
    {
        GetComponent<AudioSource>().PlayOneShot(ui_sound[(int)clip]);
    }

    void ChangeMenu(int n)
    {
        for (int i=0; i< menuArray.Length; i++ )
        {
            if (n == i)
            {
                menuArray[i].gameObject.SetActive(true);
            }
            else
            {
                menuArray[i].gameObject.SetActive(false);
            }
        } 
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
