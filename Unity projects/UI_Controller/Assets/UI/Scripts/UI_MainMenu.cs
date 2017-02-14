using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public UI_ElementButton startGameElement;

    public void OnEnable()
    {
        if (UI_Controller.Instance.inGame == false)
        {
            startGameElement.message = "Start Test";
        }
        else
        {
            {
                startGameElement.message = "Return";
            }
        }
    }

    public void StartTest()
    {
        UI_Controller.Instance.inGame = true;
        UI_Controller.Instance.ChangeState(1);//InGame
    }
}
