using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementDropdown : UI_ElementBasys
{
    public Dropdown dropdown;

    [Header("Компонент Dropdown")]
    public Image imageDropdown;
    public Image imageViewport;
    public Image imageTemplate;
    public Image imageItemBackground;
    public Image imageItemCheckmark;   
    public Image imageScrollbar;
    public Image imageScrollbarHandle;

    public Text textItemLabel;
    public Text textLabel;

    private void OnEnable()
    {
        if (useUIConfig)
        {
            //elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;

            imageBackground = SetImageElementValue(imageBackground, elementConfig.configList[UIConfigIndex].windowSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);

            imageViewport.color = elementConfig.configList[UIConfigIndex].colorNormal;
            imageItemCheckmark.color = elementConfig.configList[UIConfigIndex].colorNormal;
            imageTemplate.color = elementConfig.configList[UIConfigIndex].colorNormal;

            textItemLabel.color = elementConfig.configList[UIConfigIndex].colorText;
            textItemLabel.font = elementConfig.configList[UIConfigIndex].font;
            textLabel.color = elementConfig.configList[UIConfigIndex].colorText;
            textLabel.font = elementConfig.configList[UIConfigIndex].font;

            imageDropdown.color = elementConfig.configList[UIConfigIndex].colorNormal;
            imageScrollbarHandle.color = elementConfig.configList[UIConfigIndex].colorNormal;
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        /*
        Debug.Log("OnPointerEnter " + NameElement + " " + gameObject.name);
        EventSystem.current.SetSelectedGameObject(gameObject);

        if (useUIConfig == true)
        {
            PlaySound(UiSoundEffect.Enter);
            SelectEffect();
        }
        */
    }
}
