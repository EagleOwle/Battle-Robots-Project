using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DebugMessage : MonoBehaviour
{
    public static UI_DebugMessage Instance { get; private set; }
    public string message;
    public Color[] colorArray;
    private Text text;
    public float waitTime = 0;
    private float t;

    private void Start()
    {
        Instance = this;
        text = GetComponent<Text>();
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
