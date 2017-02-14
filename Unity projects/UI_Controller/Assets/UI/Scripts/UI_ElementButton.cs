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

        if (t <= 1)
        {
            if (fadeDown == true)
            {
                image.color = Color.Lerp(UI_Controller.Instance.colorArray[0], UI_Controller.Instance.colorArray[1], t);
            }
            else
            {
                image.color = Color.Lerp(UI_Controller.Instance.colorArray[1], UI_Controller.Instance.colorArray[0], t);
            }

            t += fadeSpeed * Time.deltaTime;
        }
        else
        {
            t = 0;
            fadeDown = !fadeDown;
        }
    }

    override public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();
        image.color = UI_Controller.Instance.colorArray[0];
    }

}
