using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseState
{
    None,
    SniperLook,
    ChangeModulLook,
    FreeLook,
    FollowLook,
    ControlLook,
    DeploedLook,
}

public enum PlayerState
{
    None,
    Spectator,
    FollowBot,
    ControlBot,
    Deploed,
    ChangeModul,
}

public enum Team
{
    None,
    Team,
}

abstract public class GameController
{

}
