using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementToggle : UI_ElementBasys
{
    [Header("Toggle image element")]
    [SerializeField]
    Image imageCheckmark;

    private void OnEnable()
    {
        if (useUIConfig)
        {
            //elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;
            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].toggleBackgroundSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            imageCheckmark = SetImageElementValue(imageCheckmark, elementConfig.configList[UIConfigIndex].togglePointSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);
            NameElement = nameElement;
        }
    }

    public override void CrossfadeEffect()
    {
        if (time <= 1)
        {
            if (fadeDown == true)
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].toggleBackgroundSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time));
                //SetTextElementValue(elementConfig.configList[UIConfigIndex].font, Color.Lerp(elementConfig.configList[UIConfigIndex].colorText, elementConfig.configList[UIConfigIndex].colorHighlighted, time));
            }
            else
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].toggleBackgroundSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time));
                //SetTextElementValue(elementConfig.configList[UIConfigIndex].font, Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorText, time));
            }

            time += fadeSpeed * Time.deltaTime;
        }
        else
        {
            time = 0;
            fadeDown = !fadeDown;
        }

    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit " + gameObject.name);
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();

        if (useUIConfig == true)
        {
            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].toggleBackgroundSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            //SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);

        }
    }
}
