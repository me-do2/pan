using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LScale : MonoBehaviour
{
    [Header("間隔(秒数)")] public float span = 5.0f;
    [Header("最大(大きさ)")] public float saidai = 3.0f;
    [Header("最小(大きさ)")] public float saisyou = 1.0f;
    [Header("ON / OFF")] public bool olsc = true;
    
    private float scaleXYZ = 1.0f;
    private float span2 = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Logging", span, span);
        InvokeRepeating("Logging2", span2, span2);
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
            // 指定した大きさ以上にならないようにする
            if (scaleXYZ >= saidai)
            {
                scaleXYZ = saidai;
            }
            scaleXYZ += 0.1f;
            this.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
        }
        else
            scaleXYZ += -0.1f;
            this.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
        // 指定した大きさ以下にならないようにする
        if (scaleXYZ <= saisyou)
        {
            scaleXYZ = saisyou;
        }    
    }
}
