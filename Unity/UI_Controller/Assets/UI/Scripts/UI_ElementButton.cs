using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ElementButton : UI_ElementBasys
{

    override public void CrossfadeEffect()
    {
        //Debug.Log("CrossfadeEffect " + name);

        if (time <= 1)
        {
            if (fadeDown == true)
            {
                image.color = Color.Lerp(UI_Controller.Singleton.colorArray[0], UI_Controller.Singleton.colorArray[1], time);
            }
            else
            {
                image.color = Color.Lerp(UI_Controller.Singleton.colorArray[1], UI_Controller.Singleton.colorArray[0], time);
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
        image.color = UI_Controller.Singleton.colorArray[0];
    }

}
