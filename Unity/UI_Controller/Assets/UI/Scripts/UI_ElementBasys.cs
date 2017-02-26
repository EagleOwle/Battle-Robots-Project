using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class UI_ElementBasys : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, ISubmitHandler, ISelectHandler
{
    [Header("Name element")]
    public string message;

    [Header("Text name element")]
    public Text nameWindowText;

    [Header("Image element")]
    public Image image;

    [Header("Speed fade process")]
    public float fadeSpeed = 1.5f;

    protected float time;
    protected bool fadeDown = true;

    private void OnEnable()
    {
        image.color = UI_Controller.Singleton.colorArray[0];
        SetNewMessage(message);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        UI_Controller.Singleton.PlaySound((UiSoundEffect.Enter));
        EventSystem.current.SetSelectedGameObject(gameObject);
        SelectEffect();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit");
        EventSystem.current.SetSelectedGameObject(null);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        UI_Controller.Singleton.PlaySound((UiSoundEffect.Up));
        //Debug.Log("OnPointerUp");
    }

    public virtual void OnSelect(BaseEventData eventData)
    {
        
        //Debug.Log("OnSelect");
    }

    public virtual void OnSubmit(BaseEventData eventData)
    {
        
        //Debug.Log("OnSubmit");
    }

    public void SelectEffect()
    {
        //Debug.Log("SelectEffect");

        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            StartCoroutine("ShowEffect");
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator ShowEffect()
    {
        yield return new WaitForEndOfFrame();

        //Debug.Log("EndOfFrame");
        CrossfadeEffect();
        SelectEffect();
    }

    public virtual void CrossfadeEffect()
    {
        //Debug.Log("CrossfadeEffect " + name);
    }

    public virtual void SetNewMessage(string newMessage)
    {
        message = newMessage;
        nameWindowText.text = newMessage;
            
    }
}
