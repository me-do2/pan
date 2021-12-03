﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuePoint : MonoBehaviour
{
    [Header("コンティニュー番号")] public int continueNum;
    [Header("音")] public AudioClip se;
    [Header("プレイヤー判定")] public PlayerTriggerCheck trigger;
    [Header("スピード")] public float speed = 3.0f;
    [Header("動く幅")] public float moveDis = 3.0f;

    private bool on = false;
    private float kakudo = 0.0f;
    private Vector3 defaultPos;

    public GameObject soccerBall;
    public GameObject Continue;
    private PlayerC sc;
    bool test = true;

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
        if (trigger.isOn && !on)
        {
            GManager.instance.continueNum = continueNum;
            GManager.instance.PlaySE(se);
            on = true;
        }

        if (on)
        {
            if (kakudo < 180.0f)
            {
                //sinカーブで振動させる
                transform.position = defaultPos + Vector3.up * moveDis * Mathf.Sin(kakudo * Mathf.Deg2Rad);

                //途中からちっちゃくなる
                if (kakudo > 90.0f)
                {
                    transform.localScale = Vector3.one * (1 - ((kakudo - 90.0f) / 90.0f));
                }
                kakudo += 180.0f * Time.deltaTime * speed;

                if (test == true)
                {
                    GameObject ContentItem = Continue;
                    GameObject cloneObject = Instantiate(soccerBall, new Vector3(2.0f, 0.0f, 0.0f), Quaternion.identity);
                    // 取得した戻り値の活用例

                    var gameObject = GameObject.Find("soccerBall2");
                    if (gameObject == true)
                    {
                        GameObject.Destroy(gameObject);  
                    }

                    cloneObject.name = "soccerBall2"; // クローンしたオブジェクトの名前を変更
                    sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
                    cloneObject.transform.parent = ContentItem.transform;
                    //cloneObject.transform.parent = this.transform; // GameManagerを親に指定
                    cloneObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f); // 座標を変更
                    test = false;
                }


            }
            else
            {
                gameObject.SetActive(false);
                on = false;
            }
        }
    }
}