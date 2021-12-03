using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpExit : MonoBehaviour
{
    [Header("入口判定")] public WarpPoint entrance;
    private Animator anim = null;
   
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (entrance.warpEx)
        {
            anim.SetTrigger("on");
            entrance.warpEx = false;
            entrance.warpEnd = true;

            Invoke("Logging", 10);//10秒後にvoid Logging()を実行する
        }
    }

    void Logging()
    {
        //ドアがずっと開かなく鳴ることを回避する
        if (entrance.warpEnd)
        entrance.warpEnd = false;
        //Debug.Log("entrance.warpEnd　　　"　+ entrance.warpEnd);
    }
}