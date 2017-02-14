using UnityEngine;
using System.Collections;

public class PlayerMouseLook : MonoBehaviour
{
    public static MouseState mouseState;
    public float sniperMouseSence;
    private int invertY = 1;
    public float speedScrollCamera = 20;
    private float rotationY;
    private float rotationX;
    //private Vector3 mouseRotation;
    //ограничния поворота камеры по осям
    //Y
    private float minimumY = -45f;
    private float maximumY = 45f;
    //ограничение скрола для камеры
    private float minimumZ = -55f;
    private float maximumZ = -15f;
    private Transform bodyTransform;
    private Vector3 posUp = new Vector3(0, 1f, 0) ;//Высота положения камеры над роботом
    private float tmpPositionY;
    private float tmpPositionZ;
    private float cameraPositionZ;
    private Vector3 tempPositionBot;
    private Vector3 cameraColliderPoint;
    private float cameraSniperZoom = 10;
    private float clampY;
    private float clampX;
    public LayerMask BackwardLayerMask;

    //Debug
    public MouseState mouseStateDB;
    public Vector3 vector1DB;
    public Vector3 vector2DB;
    //EndDebug

    void Start()
    {
        mouseState = MouseState.None;
        cameraPositionZ = -20;
    }

    void LateUpdate()
    {
        rotationX = 0;
        rotationY = 0;

        if (mouseState == MouseState.FreeLook)
        {
            SpectatorMouseRotate();
        }
        else
        {
            if (PlayerController.currentFollowTransform == null)
            {
                ChangeLookState(3);//FollowLook
            }
            else
            {
                if (mouseState == MouseState.FollowLook)
                {
                    FollowBotMouseRotate();
                }

                if (mouseState == MouseState.ControlLook)
                {
                    ControlBotMouseRotate();
                }

                if (mouseState == MouseState.SniperLook)
                {
                    SniperMouseRotate();
                }

                if (mouseState == MouseState.ChangeModulLook)
                {
                    ChangeModulMouseRotate();
                }
            }
        }

        if (mouseState == MouseState.DeploedLook)
        {
            DeploedPosition();
        }


        mouseStateDB = mouseState;
    }

    public static void ChangeLookState(int enumValue)
    {
        if (enumValue == 0)
        {
            if (PlayerController.playerState == PlayerState.ControlBot)
            {
                enumValue = 5;
            }

            if (PlayerController.playerState == PlayerState.ChangeModul)
            {
                enumValue = 2;
            }

            if (PlayerController.playerState == PlayerState.Deploed)
            {
                enumValue = 6;
            }

            if (PlayerController.playerState == PlayerState.FollowBot)
            {
                enumValue = 4;
            }

            if (PlayerController.playerState == PlayerState.Spectator)
            {
                enumValue = 3;
            }
        }

        mouseState = (MouseState)enumValue;
    }

    void DeploedPosition()
    {
        Camera.main.fieldOfView = 60;
    }

    void SpectatorMouseRotate()
    {
        Camera.main.fieldOfView = 60;

        GetMouseAxis(PlayerController.mouseSence);

        transform.eulerAngles += (Vector3.left * rotationY) + (Vector3.up * rotationX) + (Vector3.forward * 0);

        float clampY = transform.localEulerAngles.y;
        float clampX = transform.localEulerAngles.x;

        if (transform.localEulerAngles.x < 180)
        {
            clampX = Mathf.Clamp(transform.localEulerAngles.x, 0, maximumY);
        }
        else
        {
            clampX = Mathf.Clamp(transform.localEulerAngles.x, 360 + minimumY, 360);
        }

        transform.localEulerAngles = new Vector3(clampX, clampY, transform.localEulerAngles.z);

    }

    void ControlBotMouseRotate()
    {
        Camera.main.fieldOfView = 60;

        GetMouseAxis(PlayerController.mouseSence);

        //Ограничиваем угол повора камеры по оси Y
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        tmpPositionZ = cameraPositionZ * 0.1f;
        cameraColliderPoint = PlayerController.playerTransform.TransformPoint(Vector3.back * 2f);
        //-= проверка на столкновения камеры =-//
        tmpPositionZ = checkCollision(cameraColliderPoint, tempPositionBot, tmpPositionZ, Vector3.Distance(cameraColliderPoint, tempPositionBot));

        PlayerController.playerTransform.eulerAngles += new Vector3(rotationY * invertY, rotationX, 0f);

        clampY = PlayerController.playerTransform.localEulerAngles.y;
        clampX = PlayerController.playerTransform.localEulerAngles.x;

        if (PlayerController.playerTransform.localEulerAngles.x < 180)
        {
            clampX = Mathf.Clamp(PlayerController.playerTransform.localEulerAngles.x, 0, 45);
        }
        else
        {
            clampX = Mathf.Clamp(PlayerController.playerTransform.localEulerAngles.x, 360 - 45, 360);
        }

        PlayerController.playerTransform.localEulerAngles = (Vector3.right * clampX) + (Vector3.up * clampY) + (Vector3.forward * PlayerController.playerTransform.localEulerAngles.z);
        PlayerController.playerTransform.position = PlayerController.playerTransform.rotation * (Vector3.forward * tmpPositionZ) + tempPositionBot;
    }

    void FollowBotMouseRotate()
    {
        Camera.main.fieldOfView = 60;

        GetMouseAxis(PlayerController.mouseSence);

        tempPositionBot = PlayerController.currentFollowTransform.position + posUp;
        tmpPositionZ = cameraPositionZ * 0.1f;
        cameraColliderPoint = PlayerController.playerTransform.TransformPoint(Vector3.back * 2f);
        //-= проверка на столкновения камеры =-//
        tmpPositionZ = checkCollision(cameraColliderPoint, tempPositionBot, tmpPositionZ, Vector3.Distance(cameraColliderPoint, tempPositionBot));

        transform.eulerAngles += (Vector3.left * rotationY) + (Vector3.up * rotationX) + (Vector3.forward * 0);

        clampY = PlayerController.playerTransform.localEulerAngles.y;
        clampX = PlayerController.playerTransform.localEulerAngles.x;

        if (PlayerController.playerTransform.localEulerAngles.x < 180)
        {
            clampX = Mathf.Clamp(PlayerController.playerTransform.localEulerAngles.x, 0, 45);
        }
        else
        {
            clampX = Mathf.Clamp(PlayerController.playerTransform.localEulerAngles.x, 360 - 45, 360);
        }

        PlayerController.playerTransform.localEulerAngles = (Vector3.right * clampX) + (Vector3.up * clampY) + (Vector3.forward * PlayerController.playerTransform.localEulerAngles.z);
        PlayerController.playerTransform.position = PlayerController.playerTransform.rotation * (Vector3.forward * tmpPositionZ) + tempPositionBot;

    }

    void SniperMouseRotate()
    {
        float sence = (sniperMouseSence * 0.1f) * (Camera.main.fieldOfView * 0.1f);

        GetMouseAxis(sence);

        PlayerController.playerTransform.localEulerAngles += new Vector3(rotationY * invertY, rotationX, 0f);

        clampY = PlayerController.playerTransform.localEulerAngles.y;
        clampX = PlayerController.playerTransform.localEulerAngles.x;

        if (PlayerController.playerTransform.localEulerAngles.x < 180)
        {
            clampX = Mathf.Clamp(PlayerController.playerTransform.localEulerAngles.x, 0, 45);
        }
        else
        {
            clampX = Mathf.Clamp(PlayerController.playerTransform.localEulerAngles.x, 360 - 45, 360);
        }

        PlayerController.playerTransform.localEulerAngles = (Vector3.right * clampX) + (Vector3.up * clampY) + (Vector3.forward * PlayerController.playerTransform.localEulerAngles.z);
        //PlayerController.playerTransform.localEulerAngles = new Vector3(clampX, clampY, PlayerController.playerTransform.localEulerAngles.z);

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cameraSniperZoom += 15;
            if (cameraSniperZoom > 55)
            {
                cameraSniperZoom = 55;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cameraSniperZoom -= 15;
            if (cameraSniperZoom < 10)
            {
                cameraSniperZoom = 10;
            }
        }

        Camera.main.fieldOfView = cameraSniperZoom;
    }

    void ChangeModulMouseRotate()
    {
        Camera.main.fieldOfView = 60;

        rotationY = 0;
        rotationX = 0;
        cameraPositionZ = minimumZ;
        tmpPositionZ = cameraPositionZ * 0.1f;
        PlayerController.playerTransform.position = tempPositionBot + new Vector3(0, 0, tmpPositionZ);
        PlayerController.playerTransform.LookAt(tempPositionBot);

    }

    float checkCollision(Vector3 myPosition, Vector3 targetPosition, float currentDistance, float collisionDistance)
    {
        Ray rayCollision = new Ray(targetPosition, myPosition - targetPosition);
        RaycastHit hitCollision;
        if (Physics.Raycast(rayCollision, out hitCollision, collisionDistance, BackwardLayerMask))
        {//сохраняем z камеры равный расстоянию до обьекта столкновения
            if (hitCollision.distance < currentDistance * -1f)
            {
                currentDistance = hitCollision.distance;
                currentDistance = currentDistance * -1f;
            }
        }
        return currentDistance;
    }

    void GetMouseAxis(float sence)
    {
        rotationY = (Input.GetAxis("Mouse Y") * sence) * invertY;
        rotationX = (Input.GetAxis("Mouse X") * sence);
        //Приближаем камеру
        cameraPositionZ = Mathf.Clamp(cameraPositionZ + (Input.GetAxis("Mouse ScrollWheel") * speedScrollCamera), minimumZ, maximumZ);
    }
}
