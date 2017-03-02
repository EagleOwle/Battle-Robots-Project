using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChangeLevelManager : MonoBehaviour
{
    public LevelConfigList levelConfigList;

    [SerializeField]
    UI_ElementWindow elementWindow;

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
        SetDropdownMenu();
    }

    private void SetDropdownMenu()
    {
        dropdown.options = new System.Collections.Generic.List<Dropdown.OptionData>();

        for (int i = 0; i < levelConfigList.itemList.Count; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = levelConfigList.itemList[i].levelName;
            dropdown.options.Add(option);
        }

        dropdownLabelText.text = dropdown.options[0].text;
        dropdown.onValueChanged.AddListener(delegate { ApplyChangeLevel(); });

        ApplyChangeLevel();
    }

    private void ApplyChangeLevel()
    {
        prewievLevelImage.sprite = levelConfigList.itemList[dropdown.value].previewSprite;
        elementWindow.SetNewMessage( levelConfigList.itemList[dropdown.value].levelName);
        aboutLevelText.text = levelConfigList.itemList[dropdown.value].aboutLevel;
        loadScene.nextLevel = dropdown.value + 1;
    }
}
