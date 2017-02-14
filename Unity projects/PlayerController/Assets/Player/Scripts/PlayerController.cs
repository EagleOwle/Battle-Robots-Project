using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerController : MonoBehaviour 
{
    public static Transform currentFollowTransform;
    public List<Transform> followTransformList;
    public static PlayerState playerState;
    public static Transform playerTransform;
    public static Team playerTeam;
    public static Team enemyTeam;
    public static bool inGame = false;
    public static float mouseSence = 5;//Значение в пределах 0 - 10 
    public static GameObject playerBase;
    public static Vector3 moveDirection;
    public static RaycastHit hitForwardCollision;
    public float moveSpeed = 10;
    public LayerMask forwardLayerMask;

    private CharacterController characterController;
    private float frontDirection;
    private float sideDirection;
    private float upDirection;
    private float rotateDirection;
    private Ray rayForward;
    
    private bool pushFire1 = false;
    private bool pushFire2 = false;
    private int oldKeyAlfa = 0;
    private int keyAlfa = 0;
    private int followTransformIndex = 0;

    //Debug
    public Vector3 moveDirectionDB;
    public BotController botControllerDB;
    public PlayerState playerStateDB;
    public Team playerTeamDB;

    public static PlayerController Instance { get; private set; }

    void Awake()
    {
        playerState = PlayerState.None;
        playerTransform = GetComponent<Transform>();
        currentFollowTransform = playerTransform;
        Instance = this;
    }

    public void PlayerStart()
    {
        characterController = GetComponent<CharacterController>();

        PlayerController.inGame = true;
        ChangePlayerState(1); //Spectator
    }

    void FixedUpdate()
    {
        if (playerState != PlayerState.Deploed)
        {
            InputControl();
            GetForwardCollision();
        }

        if (playerState == PlayerState.Spectator)
        {
            PlayerMove();
        }

        if (playerState == PlayerState.FollowBot)
        {
            if (currentFollowTransform == null)
            {
                GetNextFollow();
            }
        }

        //Debug
        moveDirectionDB = moveDirection;
        playerStateDB = playerState;
        playerTeamDB = playerTeam;
        //EndDebug
    }

    void PlayerMove()
    {
        characterController.Move(transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }

    void InputControl()
    {
        moveDirection = Vector3.zero;
        moveDirection += Vector3.forward * Input.GetAxis("Front");
        moveDirection += Vector3.right * Input.GetAxis("Side");
        moveDirection += Vector3.up * Input.GetAxis("Vertical");
        KeyAxisFire1();//Левая кнопка мыши
        KeyAxisFire2();//Правая кнопка мыши
        keyAlfa = GetKeyAlfa();
    }

    int GetKeyAlfa()
    {
        /*
        for (int i = 0; i < (int)ModulTypeDinamic.ArrayLeight; i++)
        {
            if (Input.GetAxis("ChangeModul" + i.ToString()) != 0)
            {
                return i;
            }
        }
        */
        return 0;
        
    }

    void KeyAxisFire1()
    {
        //Левая кнопка мыши
        if (Input.GetAxis("Fire1") != 0)
        {
            if (pushFire1 == false)
            {
                //Переключение между роботами
                if (playerState == PlayerState.FollowBot)
                {
                    followTransformIndex++;
                    GetNextFollow();
                }


                pushFire1 = true;
            }
        }
        else
        {
            if (pushFire1 == true)
            {
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
                if (playerState == PlayerState.ControlBot)
                {
                    if (PlayerMouseLook.mouseState == MouseState.SniperLook)
                    {
                        PlayerMouseLook.ChangeLookState(0);
                        transform.parent = null;
                    }
                    else
                    {
                        PlayerMouseLook.ChangeLookState(1);
                    }
                }

                pushFire2 = true;
            }
        }
        else
        {
            if (pushFire2 == true)
            {
                pushFire2 = false;
            }
        }
    }

    public void ChangePlayerState(int nextState = 0)
    {
        playerState = (PlayerState)nextState;

        if (playerState == PlayerState.Spectator)
        {
            ClearControlFollow();
            currentFollowTransform = playerTransform;
        }

        if (playerState == PlayerState.FollowBot)
        {
            ClearControlFollow();
            GetNextFollow();
        }

        if (playerState == PlayerState.ControlBot)
        {
            GetControllFollow();
        }

        PlayerMouseLook.ChangeLookState(0);
    }

    void GetNextFollow()
    {
        int tmpIndex = followTransformList.Count;

        while (tmpIndex > 0)
        {
            tmpIndex--;

            if (followTransformIndex > followTransformList.Count - 1)
            {
                followTransformIndex = 0;
            }

            if (playerState == PlayerState.FollowBot)
            {
                if (followTransformList[followTransformIndex] != null)
                {
                    currentFollowTransform = followTransformList[followTransformIndex];
                    return;
                }
            }

            followTransformIndex++;
        }

        {
            ChangePlayerState(1);//Spectator
        }
    }

    void GetControllFollow()
    {
    }

    void ClearControlFollow()
    {
        
    }

    void GetForwardCollision()
    {
        rayForward = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 500));

        //rayForward = new Ray(transform.TransformDirection(Vector3.forward * 2), transform.TransformDirection(Vector3.forward * 500));

        Physics.Raycast(rayForward, out hitForwardCollision, 500, forwardLayerMask);
        {
            if (!Physics.Raycast(rayForward, out hitForwardCollision, 500, forwardLayerMask))
            { 
                hitForwardCollision.point = transform.TransformPoint(Vector3.forward * 500);

                //if (playerState == PlayerState.ControlBot || playerState == PlayerState.FollowBot)
                {
                    //UI_ConsolMessageController.Instance.SetNewMessage("");
                }
            }
            else
            {
               // if (playerState == PlayerState.ControlBot || playerState == PlayerState.FollowBot)
                {
                   // UI_ConsolMessageController.Instance.SetNewMessage(hitForwardCollision.collider.name);
                }
            }
        }
    }
}
