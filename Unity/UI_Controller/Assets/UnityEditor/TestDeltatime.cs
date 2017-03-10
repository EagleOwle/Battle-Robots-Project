using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDeltatime : MonoBehaviour
{
    public float endTime;

    public float fps1 = 5;
    public float fps2 = 30;

    public float deltatTime1;
    public float deltatTime2;

    public float resultat1;
    public float resultat2;

    private void Awake()
    {
        deltatTime1 = endTime / fps1;
        deltatTime2 = endTime / fps2;
    }

    void Calculate ()
    {
        for (int i=0; i< fps1; i++)
        {
            resultat1 += deltatTime1;
        }

        for (int i = 0; i < fps2; i++)
        {
            resultat2 += deltatTime2;
        }
    }

    private void Update()
    {
        if (endTime > Time.time)
        {
            Calculate();
        }
    }
}
