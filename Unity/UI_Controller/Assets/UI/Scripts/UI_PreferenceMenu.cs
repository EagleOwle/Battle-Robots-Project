using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PreferenceMenu : UI_MenuControllerAbstract
{
    public override void CancelKey()
    {
        ChangeMenu(0);
    }

}
