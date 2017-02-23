using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_MenuControllerAbstract : MonoBehaviour
{
    [Header("Список элементов меню")]
    public Transform[] menuArray;
    [Header("Индекс начального меню")]
    public int defaultMenuIndex;

    virtual public void ChangeMenu(int n = 0)
    {
        //Debug.Log(name + "  ChangeMenu= " + n);

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

    private void OnEnable()
    {
        ChangeMenu(defaultMenuIndex);
    }
    
}
