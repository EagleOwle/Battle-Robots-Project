using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class UI_ElementBasys : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, ISubmitHandler, ISelectHandler
{
    [Header("Текущее id элемента")]
    public int id;

    [Header("Название элемента")]
    public string message;

    [Header("Компонент Текст названия")]
    public Text nameWindowText;

    [Header("Компонент Image")]
    public Image image;

    protected float fadeSpeed = 1.5f;
    protected float t;
    protected bool fadeDown = true;

    private void OnEnable()
    {
        nameWindowText.text = message;
        image.color = UI_Controller.Instance.colorArray[0];
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter");
        UI_Controller.Instance.PlaySound((UiSoundEffect.Enter));
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
        UI_Controller.Instance.PlaySound((UiSoundEffect.Up));
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
}
