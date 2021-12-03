using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LScale2 : MonoBehaviour
{
    [Header("間隔(秒数)")] public float span = 5.0f;
    [Header("ON / OFF")] public bool olsc = true;
    [Header("左伸び")] public bool hidarinobi = false;

    private float scaleX = 1.0f;
    private float scaleY = 1.0f;
    private float scaleZ = 1.0f;
    private float span2 = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Logging", span, span);

        if (hidarinobi)
        {
            InvokeRepeating("Logging2", span2, span2);
        }
        else
        {
            InvokeRepeating("Logging3", span2, span2);
        }
    }

    void Logging()
    {
        if (olsc)
        {
            olsc = false;
        }
        else
            olsc = true;
        //Debug.LogFormat("{0}秒経過", span);
    }

    void Logging2()
    {
        if (olsc)
        {
        // -2以上にならないようにする
        if (scaleX <= -2.0f)
        {
        scaleX = -2.0f;
        }
        scaleX += -0.1f;
        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
        else
        scaleX += 0.1f;
        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        if (scaleX >= -1.0f)
        {
        scaleX = -1.0f;
        }
    }

    void Logging3()
    {
        if (olsc)
        {
        // 2以上にならないようにする
        if (scaleX >= 2.0f)
        {
        scaleX = 2.0f;
        }
        scaleX += 0.1f;
        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
        else
        scaleX += -0.1f;
        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        if (scaleX <= 1.0f)
        {
        scaleX = 1.0f;
        }
    }
}
