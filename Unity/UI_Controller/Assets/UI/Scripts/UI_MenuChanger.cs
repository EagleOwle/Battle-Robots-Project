using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuChanger : MonoBehaviour
{
    [Header("Menu elements")]
    [Tooltip ("Set element menu")]
    public Transform[] menuArray;

    [Header("First enable menu")]
    [Tooltip("Enable Menu by index if call OnEnable()")]
    public int menuIndex = 0;

    private void OnEnable()
    {
        ChangeMenu(menuIndex);
    }

    public void ChangeMenu(int n = 0)
    {
        if (menuArray.Length <= n)
        {
            UI_DebugMessage.Singleton.ShowNewMessage("No this value menu", 2);
            Debug.Log("No this value menu " + "Change menu= " + n + " menuArray.Length= " + menuArray.Length);
            return;
        }

        for (int i = 0; i < menuArray.Length; i++)
        {
            if (n == i)
            {
                menuArray[i].gameObject.SetActive(true);
            }
            else
            {
                menuArray[i].gameObject.SetActive(false);
            }
        }
    }

    public void KeyCancel(int index = 0)
    {
        ChangeMenu(index);
    }

}
