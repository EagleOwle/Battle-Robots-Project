using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum UiSoundEffect
{
    Enter,
    Up,
    None,
    Slider,
}

public abstract class UI_ElementBasys : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, ISubmitHandler, ISelectHandler
{
    [SerializeField]
    protected bool useUIConfig = true;

    [SerializeField]
    protected int UIConfigIndex = 0;

    [SerializeField]
    protected bool controlNameText = true;

    [Header("Name element")]
    [SerializeField]
    protected string nameElement;
    public string NameElement
    {
        get
        {
            return nameElement;
        }
        set
        {
            if (controlNameText == true)
            {
                nameElement = value;
                if (nameElementText != null)
                {
                    nameElementText.text = value;
                }
            }
        }
    }

    [Header("Text name element")]
    public Text nameElementText;

    [Header("Image element")]
    [SerializeField]
    protected Image imageBackground;

    [Header("Speed fade process")]
    public float fadeSpeed = 1.5f;

    protected float time;
    protected bool fadeDown = true;

    private UIConfigList _elementConfig;

    public UIConfigList elementConfig
    {
        get
        {
            if (_elementConfig == null)
            {
                _elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;

                if (_elementConfig == null)
                {
                    Debug.Log("No elementConfig ");
                }
            }
            return _elementConfig;
        }

        private set
        {
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter " + NameElement + " " + gameObject.name);
        EventSystem.current.SetSelectedGameObject(gameObject);

        if (useUIConfig == true)
        {
            //Debug.Log("PlaySound Enter" + gameObject.name);
            PlaySound(UiSoundEffect.Enter);
            SelectEffect();
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit " + gameObject.name);
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();

        if (useUIConfig == true)
        {
            if (imageBackground == null)
            {
                UI_DebugMessage.Singleton.ShowNewMessage("No set imageBackground in " + gameObject.name, 5);
            }
            else
            {
                imageBackground = SetImageElementValue(imageBackground, imageBackground.sprite, elementConfig.configList[UIConfigIndex].colorNormal);
            }
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp");
        //Debug.Log("PlaySound Click" + gameObject.name);
        PlaySound(UiSoundEffect.Up);
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

    public virtual void PlaySound(UiSoundEffect soundEffect = UiSoundEffect.None)
    {
        if (UI_Controller.Singleton.audioSource == null)
        { UI_DebugMessage.Singleton.ShowNewMessage("No audioSource in UI_Controller"); return; }

        switch (soundEffect)
        {
            case UiSoundEffect.None:
                {
                    break;
                }
            case UiSoundEffect.Enter:
                {
                    UI_Controller.Singleton.audioSource.PlayOneShot(elementConfig.configList[UIConfigIndex].clickSound);
                    break;
                }
            case UiSoundEffect.Up:
                {
                    UI_Controller.Singleton.audioSource.PlayOneShot(elementConfig.configList[UIConfigIndex].enterSound);
                    break;
                }

            case UiSoundEffect.Slider:
                {
                    UI_Controller.Singleton.audioSource.PlayOneShot(elementConfig.configList[UIConfigIndex].sliderSound);
                    break;
                }
        }
    }

    public Image SetImageElementValue(Image image, Sprite sprite, Color color)
    {
        if (image != null)
        {
            image.sprite = sprite;
            image.color = color;
            return image;
        }
        else
        {
            UI_DebugMessage.Singleton.ShowNewMessage("No ImageElement");
            return null;
        }
    }

    public void SetTextElementValue(Font font, Color color)
    {
        if (nameElementText != null)
        {
            nameElementText.font = font;
            nameElementText.color = color;
        }
        else
        {
            UI_DebugMessage.Singleton.ShowNewMessage("No ElementText");
        }
    }

    public void SetColor(Image image, Color color)
    {
        if (image != null)
        {
            image.color = color;
        }
        else
        {
            UI_DebugMessage.Singleton.ShowNewMessage("No Image");
        }
    }
}
