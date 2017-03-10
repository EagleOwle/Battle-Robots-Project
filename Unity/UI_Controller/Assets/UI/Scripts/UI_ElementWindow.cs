using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementWindow : UI_ElementBasys
{
    private void OnEnable()
    {
        if (useUIConfig)
        {
            //elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;
            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].windowSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);
            NameElement = nameElement;
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter " + NameElement);
       
    }

}
