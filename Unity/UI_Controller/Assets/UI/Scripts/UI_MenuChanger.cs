using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuChanger : MonoBehaviour
{
    [Header("Menu elements")]
    [Tooltip ("Set element menu")]
    public Transform[] menuArray;

    [Header("Menu by Cancel key")]
    [Tooltip("Eneble element perent menu by this value")]
    public int GoBackValue = 0;

    public void ChangeMenu(int n = 0)
    {
        for (int i = 0; i < menuArray.Length; i++)
        {
            if (n == i)
            {
                UI_DebugMessage.Singleton.ShowNewMessage("New Menu   " + menuArray[i].transform.parent.name);
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

    private void OnEnable()
    {
        ChangeMenu(0);
    }

}
