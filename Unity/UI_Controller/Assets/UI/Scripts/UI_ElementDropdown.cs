using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ElementDropdown : UI_ElementBasys
{
    public Dropdown dropdown;

    [Header("Компонент Image")]
    public Image imageViewport;
    public Image imageScrollRectFild;
    public Image imageItemBackground;
    public Image imageItemCheckmark;

    public Image imageScrollbarBackground;
    public Image imageScrollbarHandle;

    public Text textItemLabel;
    


    private void OnEnable()
    {
        image.color = UI_Controller.Singleton.colorArray[0];
        SetNewMessage(message);
        imageViewport.color = UI_Controller.Singleton.colorArray[0];
    }
}
