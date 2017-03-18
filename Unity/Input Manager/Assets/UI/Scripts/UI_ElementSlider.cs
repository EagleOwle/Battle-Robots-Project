using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementSlider : UI_ElementBasys
{
    [Header("Компонент Image поля")]
    [SerializeField] Image imageFill;

    [Header("Компонент Image поля")]
    [SerializeField]
    Image imageHandle;

    [Header("Компонент Text для значения слайдера")]
    [SerializeField]
    Text valueText;

    [SerializeField]
    bool showValue;

    [SerializeField]
    Slider slider;

    private void OnEnable()
    {
        if (useUIConfig)
        {
            //elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;

            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            imageHandle = SetImageElementValue(imageHandle, elementConfig.configList[UIConfigIndex].panelSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            SetColor(imageFill, elementConfig.configList[UIConfigIndex].colorNormal);
            SetColor(imageHandle, elementConfig.configList[UIConfigIndex].colorNormal);
            SetColor(imageBackground, elementConfig.configList[UIConfigIndex].colorNormal);

            if (showValue)
            {
                valueText.color = elementConfig.configList[UIConfigIndex].colorText;
                valueText.font = elementConfig.configList[UIConfigIndex].font;
            }

            NameElement = nameElement;
            nameElementText.color = elementConfig.configList[UIConfigIndex].colorText;
            nameElementText.font = elementConfig.configList[UIConfigIndex].font;
        }

        if (showValue == true)
        {
            SetValueChangeText();
        }
    }

    private void SetValueChangeText()
    {
        valueText.text = slider.value.ToString("f0");
    }

    override public void CrossfadeEffect()
    {
        //Debug.Log("CrossfadeEffect " + name);

        if (time <= 1)
        {
            if (fadeDown == true)
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time));
                imageFill.color = Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time);
                imageHandle.color = Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time);
            }
            else
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time));
                imageFill.color = Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time);
                imageHandle.color = Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time);
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
        imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, elementConfig.configList[UIConfigIndex].colorNormal);
    }

    public void SliderValueChenge()
    {
        SetValueChangeText();

        if (useUIConfig)
        {
            PlaySound(UiSoundEffect.Slider);
        }
    }
}
