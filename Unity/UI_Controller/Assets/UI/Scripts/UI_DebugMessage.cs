using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DebugMessage : MonoBehaviour
{
    private static UI_DebugMessage _singleton;

    public static UI_DebugMessage Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = GameObject.FindObjectOfType<UI_DebugMessage>();
            }

            return _singleton;
        }
    }

    [Header("New message")]
    [Tooltip("Set new message")]
    public string message;
    [Header("Color for color crossfade")]
    [Tooltip("Set color for crossfade")]
    public Color[] colorArray;

    [Tooltip("Wait time for hide new message")]
    public float waitTime = 1;

    [SerializeField] Text text;   
    private float t;

    private void Start()
    {
        ShowNewMessage("");
    }

    public void ShowNewMessage(string message)
    {
        text.text = message;
        text.color = colorArray[0];
        t = 0;
        StopAllCoroutines();
        StartCoroutine("Wait");
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("Crossfade");
    }

    public IEnumerator Crossfade()
    {
        yield return new WaitForEndOfFrame();

        if (t < 1)
        {
            text.color = Color.Lerp(colorArray[0], colorArray[1], t);
            t += Time.deltaTime;
            StartCoroutine("Crossfade");
        }
    }
}
