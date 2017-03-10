using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementButton : UI_ElementBasys
{
    private void OnEnable()
    {
        if (useUIConfig)
        {
            //elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;

            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);
            NameElement = nameElement;
        }
    }

    override public void CrossfadeEffect()
    {
        if (time <= 1)
        {
            if (fadeDown == true)
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time));
            }
            else
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].buttonSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time));
            }

            time += fadeSpeed * Time.deltaTime;
        }
        else
        {
            time = 0;
            fadeDown = !fadeDown;
        }

    }
}
