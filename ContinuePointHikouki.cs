using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ContinuePointHikouki : MonoBehaviour
{
    [Header("コンティニュー番号")] public int continueNum;
    [Header("音")] public AudioClip se;
    [Header("プレイヤー判定")] public PlayerTriggerCheck trigger;
    [Header("スピード")] public float speed = 3.0f;
    [Header("動く幅")] public float moveDis = 3.0f;

    private bool on = false;
    
    private float kakudo = 0.0f;
    private Vector3 defaultPos;

    [Header("飛行機オブジェクト")] public GameObject hikouKI;
    [Header("playerオブジェクト")] public GameObject playER;
    [Header("カメラ切り替え")] public bool CMvcam = false;
    [Header("カメラ１")] public GameObject vcam1 = null;
    [Header("カメラ2")] public GameObject vcam2 = null;
    [Header("飛行機出現ポイント")] public GameObject Continue;
    [Header("カメラコライダー2")] public GameObject CC2;
    [Header("モバイルコントロール")] public MobileControlRig mobilec;
    [Header("ボールボタン")] public GameObject ballBt;
    [Header("ボールボタン3")] public GameObject ballBt3;
    [Header("ボールボタン4")] public GameObject ballBt4;
    [Header("ジャンプボタン")] public GameObject jumpB;
    [Header("左ボタン確認")] public GameObject LeftButton;
    private bool LButton = false;

    [HideInInspector] public bool playerEnable = true;
    private Player pl;



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

                if (playerEnable == true)
                {
                    playerEnable = false;
                    //playER.SetActive(false);
                    pl = GameObject.Find("Player").GetComponent<Player>();
                    pl.sr.enabled = false;
                    playER.gameObject.transform.parent = hikouKI.gameObject.transform; //飛行機ぱんちゃんをplayerの親要素に設定
                    
                    hikouKI.SetActive(true);//飛行機から降りたらfalseにする(飛行機)
                    mobilec.GetComponent<MobileControlRig>().enabled = false;//飛行機から降りたらtrueにする(スクリプト)
                    ballBt.SetActive(false);//飛行機から降りたらtrueにする(ボールボタン)
                    jumpB.SetActive(false);//飛行機から降りたらtrueにする(ジャンプボタン)

                    LButton = (LeftButton.activeSelf);
                    if (LButton)
                    {
                        ballBt3.SetActive(true);//飛行機から降りたらfalseにする(ボールボタン３)
                        ballBt4.SetActive(true);//飛行機から降りたらfalseにする(ボールボタン４)
                    }
                    else if (!LButton)
                    {
                        ballBt3.SetActive(true);//飛行機から降りたらfalseにする(ボールボタン３)
                        RectTransform rectTransform3 = ballBt3.GetComponent<RectTransform>();
                        rectTransform3.localPosition = new Vector3(1.4f, -7.0f, 0);

                        ballBt4.SetActive(true);//飛行機から降りたらfalseにする(ボールボタン４)
                        RectTransform rectTransform4 = ballBt4.GetComponent<RectTransform>();
                        rectTransform4.localPosition = new Vector3(-0.5f, -7.0f, 0);
                    }

                    if (CMvcam)
                    {
                        CMvcam = false;
                        vcam1.SetActive(false);
                        CC2.SetActive(true);
                        vcam2.SetActive(true);
                    }
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