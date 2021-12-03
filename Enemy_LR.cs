using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LR : MonoBehaviour
{
    [Header("間隔(秒数)")] public float span = 3.0f;
    [Header("ON / OFF")] public bool olsc = false;
    [Header("右向き")] public bool migimuki;

    void Start()
    {
        if (migimuki)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (!migimuki)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        InvokeRepeating("Logging", span, span);
    }

    void Logging()
    {
        if (olsc)
        {
            //this.transform.localScale = new Vector3(-1, 1, 1);
            olsc = false;
        }
        else
            //this.transform.localScale = new Vector3(1, 1, 1);
            olsc = true;
    }
}