using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (image != null)
        {
            image.color = UI_Controller.Singleton.colorArray[0];
        }

        SetNewMessage(message);
        imageViewport.color = UI_Controller.Singleton.colorArray[0];
        imageItemCheckmark.color = UI_Controller.Singleton.colorArray[0];
        imageTemplate.color = UI_Controller.Singleton.colorArray[0];
        textItemLabel.color = UI_Controller.Singleton.colorArray[5];
        textLabel.color = UI_Controller.Singleton.colorArray[5];
        imageDropdown.color = UI_Controller.Singleton.colorArray[0];
        imageScrollbarHandle.color = UI_Controller.Singleton.colorArray[0];
    }
}
