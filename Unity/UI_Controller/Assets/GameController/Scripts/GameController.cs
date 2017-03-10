using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeModul
{
    Random,
    ByValue,
}

public enum SM_BotState
{
    None,
    Destroy,
    Hide,
    Deploed,
    Off,
    On,
}

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




public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public static float distToHit = 500; //расстояние "сведения" оружия
    public static Vector3 keyDirection;
    public static float keyFire1;
    public static float keyFire2;
    private bool pushFire1 = false;
    private bool pushFire2 = false;
    //Debug
    public Vector3 keyDirectionDB;
    public float keyFire1DB;
    public float keyFire2DB;

    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        InputControl();

        //Debug
        keyDirectionDB = keyDirection;
        keyFire1DB = keyFire1;
        keyFire2DB = keyFire2;
        //EndDebug
    }

    void InputControl()
    {
        
            keyDirection = Vector3.zero;
            keyDirection += Vector3.forward * Input.GetAxis("Front");
            keyDirection += Vector3.right * Input.GetAxis("Side");
            keyDirection += Vector3.up * Input.GetAxis("Vertical");
            KeyAxisFire1();//Левая кнопка мыши
            KeyAxisFire2();//Правая кнопка мыши
    }

    void KeyAxisFire1()
    {
        //Левая кнопка мыши
        if (Input.GetAxis("Fire1") != 0)
        {
            if (pushFire1 == false)
            {
                keyFire1 = Input.GetAxis("Fire1");
                pushFire1 = true;
            }
        }
        else
        {
            if (pushFire1 == true)
            {
                keyFire1 = 0;
                pushFire1 = false;
            }
        }
    }

    void KeyAxisFire2()
    {
        //Правая кнопка мыши
        if (Input.GetAxis("Fire2") != 0)
        {
            if (pushFire2 == false)
            {
                keyFire2 = Input.GetAxis("Fire2");
                pushFire2 = true;
            }
        }
        else
        {
            if (pushFire2 == true)
            {
                keyFire2 = 0;
                pushFire2 = false;
            }
        }
    }

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }
}
