using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_ResolutionConfig : MonoBehaviour 
{
    public Dropdown resDropdown; // выпадающая менюшка
    public Text currentResolution;//Текущее разрешение экрана
    private Resolution[] resolutionsArray;//Возможные разрешения экрана 
    public int minHeight = 480; // фильтр разрешения экрана по высоте
    private int resolutionsList_id;
    public Toggle fullscreenToggle; // переключатель полноэкранный/оконный режим

    public void OnEnable()
    {
        resolutionsArray = Screen.resolutions;
        ReBuildResolutionsList();
        SetDropdownMenu();
    }

    void SetDropdownMenu()
    {
        resDropdown.options = new System.Collections.Generic.List<Dropdown.OptionData>();

        for (int i = 0; i < resolutionsArray.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = resolutionsArray[i].width + " x " + resolutionsArray[i].height;
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
        Screen.SetResolution(resolutionsArray[resolutionsList_id].width, resolutionsArray[resolutionsList_id].height, fullscreenToggle.isOn);
        currentResolution.text = resolutionsArray[resolutionsList_id].width + " x " + resolutionsArray[resolutionsList_id].height;
    }

    // фильтр разрешения экрана по высоте
    void ReBuildResolutionsList()
    {
        int x = 0;
        foreach (Resolution element in resolutionsArray)
        {
            if (element.height >= minHeight) x++;
        }
        Resolution[] pureArray = new Resolution[x];
        x = 0;
        foreach (Resolution element in resolutionsArray)
        {
            if (element.height >= minHeight)
            {
                pureArray[x] = element;
                x++;
            }
        }
        resolutionsArray = new Resolution[pureArray.Length];
        for (int i = 0; i < resolutionsArray.Length; i++)
        {
            resolutionsArray[i] = pureArray[i];
        }
    }
}
