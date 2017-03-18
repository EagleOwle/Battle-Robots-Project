using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Element : UI_ElementBasys
{
    private void OnEnable()
    {
        if (useUIConfig)
        {
            if (imageBackground!= null)
            {
                imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].windowSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            }

            SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);
            NameElement = nameElement;
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter " + NameElement);

    }
}
