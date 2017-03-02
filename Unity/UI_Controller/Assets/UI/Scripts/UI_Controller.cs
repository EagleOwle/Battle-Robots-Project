using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Color menu")]
    [Tooltip("Array 0=normal, 1=highlighted, 2=pressed, 3=disabled, 4=alarm, 5=text")]
    public Color[] colorArray;

    [Header("Sound menu")]
    public AudioClip[] ui_sound;

    public void ShowDebugMessage(string message)
    {
        UI_DebugMessage.Singleton.ShowNewMessage(message);
    }

    public void PlaySound(UiSoundEffect clip)
    {
        GetComponent<AudioSource>().PlayOneShot(ui_sound[(int)clip]);
    }

    public void QuitApplication()
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
