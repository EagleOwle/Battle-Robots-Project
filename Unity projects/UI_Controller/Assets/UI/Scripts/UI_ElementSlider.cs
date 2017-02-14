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
        image.color = UI_Controller.Instance.colorArray[0];
        imageFill.color = UI_Controller.Instance.colorArray[0];
        imageHandle.color = UI_Controller.Instance.colorArray[0];

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

        if (t <= 1)
        {
            if (fadeDown == true)
            {
                image.color = Color.Lerp(UI_Controller.Instance.colorArray[0], UI_Controller.Instance.colorArray[1], t);
                imageFill.color = Color.Lerp(UI_Controller.Instance.colorArray[0], UI_Controller.Instance.colorArray[1], t);
                imageHandle.color = Color.Lerp(UI_Controller.Instance.colorArray[0], UI_Controller.Instance.colorArray[1], t);
            }
            else
            {
                image.color = Color.Lerp(UI_Controller.Instance.colorArray[1], UI_Controller.Instance.colorArray[0], t);
                imageFill.color = Color.Lerp(UI_Controller.Instance.colorArray[1], UI_Controller.Instance.colorArray[0], t);
                imageHandle.color = Color.Lerp(UI_Controller.Instance.colorArray[1], UI_Controller.Instance.colorArray[0], t);
            }

            t += fadeSpeed * Time.deltaTime;
        }
        else
        {
            t = 0;
            fadeDown = !fadeDown;
        }
    }

    override public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();
        image.color = UI_Controller.Instance.colorArray[0];
    }
}
