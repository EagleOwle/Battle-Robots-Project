using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSupport : MonoBehaviour
{
    public static DevSupport instance;
    public PlayerState playerState;
    public bool playerStart = false;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (playerStart == true)
        {
            PlayerController.Instance.PlayerStart();
            playerStart = false;
        }

        if (PlayerController.playerState != playerState )
        {
            PlayerController.Instance.ChangePlayerState((int)playerState);
        }
    }
}
