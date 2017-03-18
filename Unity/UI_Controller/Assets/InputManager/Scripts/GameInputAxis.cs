using UnityEngine;
using System.Collections;

public class GameInputAxis : MonoBehaviour
{
    public float sence = 0.1f;

    public float _axisValue;
    public float AxisValue
    {
        get { return _axisValue; }

        set { _axisValue = Mathf.Clamp(value, -1, 1); }
    }

    public void AxisUp()
    {
        AxisValue += Time.deltaTime;
    }

    public void AxisDown()
    {
        AxisValue -= Time.deltaTime;
    }

    /*
    public void AxisClear()
    {
        if (AxisValue > 0)
        {
            AxisValue -= Time.deltaTime;
        }

        if (AxisValue < 0)
        {
            AxisValue += Time.deltaTime;
        }
    }
    */

    public IEnumerator AxisClear()
    {
        yield return new WaitForEndOfFrame();

        if (AxisValue != 0)
        {

            if (AxisValue > 0)
            {
                AxisValue -= Time.deltaTime;
                StartCoroutine("AxisClear");
            }

            if (AxisValue < 0)
            {
                AxisValue += Time.deltaTime;
                StartCoroutine("AxisClear");
            }
        }
    }
}
