using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChangeLevelManager : MonoBehaviour
{
    public LevelConfigList levelConfigList;

    [SerializeField]
    UIConfigList elementConfig;

    public bool useUIConfig = true;

    [SerializeField]
    UI_ElementPanel nameLevel;

    [SerializeField]
    UI_LoadScene loadScene;

    [SerializeField]
    Image prewievLevelImage;

    [SerializeField]
    Text aboutLevelText;

    [SerializeField]
    Dropdown dropdown;

    [SerializeField]
    Text dropdownLabelText;

    private void OnEnable()
    {
        elementConfig = Resources.Load("Config/UIConfig") as UIConfigList;
        SetDropdownMenu();
    }

    private void SetDropdownMenu()
    {
        dropdown.options = new System.Collections.Generic.List<Dropdown.OptionData>();

        for (int i = 0; i < levelConfigList.configList.Count; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = levelConfigList.configList[i].levelName;
            dropdown.options.Add(option);
        }

        dropdownLabelText.text = dropdown.options[0].text;

        if (useUIConfig == true)
        {
            dropdownLabelText.color = elementConfig.configList[0].colorNormal;
            dropdownLabelText.font = elementConfig.configList[0].font;
        }

        dropdown.onValueChanged.AddListener(delegate { ApplyChangeLevel(); });

        ApplyChangeLevel();
    }

    private void ApplyChangeLevel()
    {
        prewievLevelImage.sprite = levelConfigList.configList[dropdown.value].previewSprite;
        nameLevel.NameElement = levelConfigList.configList[dropdown.value].levelName;
        aboutLevelText.text = levelConfigList.configList[dropdown.value].aboutLevel;

        if (useUIConfig == true)
        {
            aboutLevelText.color = elementConfig.configList[0].colorText;
            aboutLevelText.font = elementConfig.configList[0].font;
        }

        loadScene.nextLevel = dropdown.value + 1;
    }
}
