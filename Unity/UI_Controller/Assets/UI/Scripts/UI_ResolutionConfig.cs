using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ResolutionConfig : MonoBehaviour 
{
    public Dropdown resDropdown; // выпадающая менюшка
    public Text currentResolution;//Текущее разрешение экрана
    private Resolution[] resolutionsList;//Возможные разрешения экрана 
    public int minHeight = 480; // фильтр разрешения экрана по высоте
    private int resolutionsList_id;
    public Toggle fullscreenToggle; // переключатель полноэкранный/оконный режим

    public void OnEnable()
    {
        resolutionsList = Screen.resolutions;
        ReBuildResolutionsList();
        SetDropdownMenu();
    }

    void SetDropdownMenu()
    {
        resDropdown.options = new System.Collections.Generic.List<Dropdown.OptionData>();

        for (int i = 0; i < resolutionsList.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = resolutionsList[i].width + " x " + resolutionsList[i].height;
            resDropdown.options.Add(option);
        }

        currentResolution.text = Screen.width + " x " + Screen.height;

        resDropdown.value = resolutionsList_id;
        resDropdown.onValueChanged.AddListener(delegate { ApplyResolution(); });
        fullscreenToggle.onValueChanged.AddListener(delegate { ApplyResolution(); });
    }

    void SetID()
    {
        resolutionsList_id = resDropdown.value;
    }

    void ApplyResolution()
    {
        resolutionsList_id = resDropdown.value;
        Screen.SetResolution(resolutionsList[resolutionsList_id].width, resolutionsList[resolutionsList_id].height, fullscreenToggle.isOn);
        currentResolution.text = resolutionsList[resolutionsList_id].width + " x " + resolutionsList[resolutionsList_id].height;
    }

    // фильтр разрешения экрана по высоте
    void ReBuildResolutionsList()
    {
        int x = 0;
        foreach (Resolution element in resolutionsList)
        {
            if (element.height >= minHeight) x++;
        }
        Resolution[] pureArray = new Resolution[x];
        x = 0;
        foreach (Resolution element in resolutionsList)
        {
            if (element.height >= minHeight)
            {
                pureArray[x] = element;
                x++;
            }
        }
        resolutionsList = new Resolution[pureArray.Length];
        for (int i = 0; i < resolutionsList.Length; i++)
        {
            resolutionsList[i] = pureArray[i];
        }
    }
}
