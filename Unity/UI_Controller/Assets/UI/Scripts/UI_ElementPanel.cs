using UnityEngine.EventSystems;
using UnityEngine;

public class UI_ElementPanel : UI_ElementBasys
{
    private void OnEnable()
    {
        if (useUIConfig)
        {
            //elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;
            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].panelSprite, elementConfig.configList[UIConfigIndex].colorNormal);
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
                imageBackground = SetImageElementValue(imageBackground, imageBackground.sprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time));
            }
            else
            {
                imageBackground = SetImageElementValue(imageBackground, imageBackground.sprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time));
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
