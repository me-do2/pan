using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class zweiCamera : MonoBehaviour
{
    [Header("2カメ")] public bool nikame = false;
    public CinemachineVirtualCamera vcamera1 = null;
    public CinemachineVirtualCamera vcamera2 = null;
    [Header("ボススクリプト")] public Enemy_Gunner BOSS = null;
    [HideInInspector] public bool nikameEnd = false;
    [HideInInspector] public bool startEnsyutu = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (nikame)
        {
            //Debug.Log("ワープポイント２カメ" + nikame);
            if (BOSS.cameraDooon && !nikameEnd)
            {
                //Debug.Log("ボスにドーンワープポイント" + BOSS.cameraDooon);
                nikameEnd = true;
                vcamera1.Priority = 11;
                //Debug.Log("ボスカメラプライオリティ" + vcamera1.Priority);
                Invoke("Logging3", 11.1f);//11.1秒後にvoid Logging()を実行する
            }

            else if (BOSS.isCharacter && !startEnsyutu)
            {
                startEnsyutu = true;
                vcamera1.Priority = 11;
                Invoke("Logging5", 5);
            }
        }
    }

    void Logging3()
    {
        vcamera1.Priority = 9;
        vcamera2.Priority = 11;
        Invoke("Logging4", 5);//5秒後にvoid Logging()を実行する
    }

    void Logging4()
    {
        vcamera2.Priority = 9;
    }

    void Logging5()
    {
        vcamera1.Priority = 9;
    }
}
