using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum ElementClass
{
    Panel,
    Window,
    Button,
    Dropdown,
}

public class UI_Element : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, ISubmitHandler, ISelectHandler
{
    public bool useUIConfig = true;
    public int UIConfigIndex = 0;

    public ElementClass elementClass;

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
            nameElement = value;
            if (nameElementText != null)
            {
                nameElementText.text = value;
            }
        }
    }

    [Header("Text name element")]
    public Text nameElementText;

    [Header("Image element")]
    [SerializeField]
    Image imageElement;

    [Header("Speed fade process")]
    public float fadeSpeed = 1.5f;

    protected float time;
    protected bool fadeDown = true;

    private Sprite currentSprite;
    protected UIConfigList elementConfig;

    private void OnEnable()
    {
        if (useUIConfig)
        {
            elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;

            if (elementClass == ElementClass.Window)
            {
                currentSprite = elementConfig.configList[UIConfigIndex].windowSprite;
            }

            if (elementClass == ElementClass.Button)
            {
                currentSprite = elementConfig.configList[UIConfigIndex].buttonSprite;
            }

            SetImageElementValue(currentSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            SetTextElementValue(elementConfig.configList[UIConfigIndex].font, elementConfig.configList[UIConfigIndex].colorText);
            NameElement = nameElement;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("OnPointerEnter " + NameElement);
        EventSystem.current.SetSelectedGameObject(gameObject);

        if (useUIConfig == true)
        {
            PlaySound(UiSoundEffect.Enter);
            SelectEffect();
        }
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

    public void CrossfadeEffect()
    {
        if (time <= 1)
        {
            if (fadeDown == true)
            {
                SetImageElementValue(currentSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorNormal, elementConfig.configList[UIConfigIndex].colorHighlighted, time));
            }
            else
            {
                SetImageElementValue(currentSprite, Color.Lerp(elementConfig.configList[UIConfigIndex].colorHighlighted, elementConfig.configList[UIConfigIndex].colorNormal, time));
            }

            time += fadeSpeed * Time.deltaTime;
        }
        else
        {
            time = 0;
            fadeDown = !fadeDown;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("OnPointerExit " + gameObject.name);
        EventSystem.current.SetSelectedGameObject(null);
        StopAllCoroutines();

        if (useUIConfig == true)
        {
            if (imageElement != null)
            {
                SetImageElementValue(currentSprite, elementConfig.configList[UIConfigIndex].colorNormal);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp");
        PlaySound(UiSoundEffect.Up);
    }

    public void OnSelect(BaseEventData eventData)
    {

        //Debug.Log("OnSelect");
    }

    public void OnSubmit(BaseEventData eventData)
    {

        //Debug.Log("OnSubmit");
    }

    public void SetImageElementValue(Sprite sprite, Color color)
    {
        if (imageElement != null)
        {
            imageElement.sprite = sprite;
            imageElement.color = color;
        }
        else
        {
            UI_DebugMessage.Singleton.ShowNewMessage("No ImageElement");
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

    public void PlaySound(UiSoundEffect soundEffect = UiSoundEffect.None)
    {
        switch (soundEffect)
        {
            case UiSoundEffect.None:
                {
                    break;
                }
            case UiSoundEffect.Enter:
                {
                    GetComponentInParent<AudioSource>().PlayOneShot(elementConfig.configList[UIConfigIndex].clickSound);
                    break;
                }
            case UiSoundEffect.Up:
                {
                    break;
                }
        }
    }
}
