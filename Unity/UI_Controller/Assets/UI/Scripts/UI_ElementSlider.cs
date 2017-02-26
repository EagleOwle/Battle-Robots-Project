using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementSlider : UI_ElementBasys
{
    [Header("Компонент Image поля")]
    public Image imageFill;

    [Header("Компонент Image поля")]
    public Image imageHandle;

    [Header("Компонент Text для значения слайдера")]
    public Text valueText;

    public bool showValue;

    private void OnEnable()
    {
        nameWindowText.text = message;
        image.color = UI_Controller.Singleton.colorArray[0];
        imageFill.color = UI_Controller.Singleton.colorArray[0];
        imageHandle.color = UI_Controller.Singleton.colorArray[0];

        if (showValue == true)
        {
            SetValueChangeText();
        }
    }

    public void SetValueChangeText()
    {
        valueText.text = GetComponent<Slider>().value.ToString("f0");
    }

    override public void CrossfadeEffect()
    {
        //Debug.Log("CrossfadeEffect " + name);

        if (time <= 1)
        {
            if (fadeDown == true)
            {
                image.color = Color.Lerp(UI_Controller.Singleton.colorArray[0], UI_Controller.Singleton.colorArray[1], time);
                imageFill.color = Color.Lerp(UI_Controller.Singleton.colorArray[0], UI_Controller.Singleton.colorArray[1], time);
                imageHandle.color = Color.Lerp(UI_Controller.Singleton.colorArray[0], UI_Controller.Singleton.colorArray[1], time);
            }
            else
            {
                image.color = Color.Lerp(UI_Controller.Singleton.colorArray[1], UI_Controller.Singleton.colorArray[0], time);
                imageFill.color = Color.Lerp(UI_Controller.Singleton.colorArray[1], UI_Controller.Singleton.colorArray[0], time);
                imageHandle.color = Color.Lerp(UI_Controller.Singleton.colorArray[1], UI_Controller.Singleton.colorArray[0], time);
            }

            time += fadeSpeed * Time.deltaTime;
        }
        else
        {
            time = 0;
            fadeDown = !fadeDown;
        }
    }

    override public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();
        image.color = UI_Controller.Singleton.colorArray[0];
    }
}
