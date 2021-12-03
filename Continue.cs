using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    [Header("コンティニュー番号")] public int continueNum;
    [Header("プレイヤー判定")] public PlayerTriggerCheck trigger;
    
    private Vector3 defaultPos;
    void Start()
    {
        //初期化
        if (trigger == null)
        {
            Debug.Log("インスペクターの設定が足りません");
            Destroy(this);
        }
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが範囲内に入った
        if (trigger.isOn)
        {
            GManager.instance.continueNum = continueNum;
            gameObject.SetActive(false);
        }
    }
}
