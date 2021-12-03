using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class BallButton : MonoBehaviour
{
    public static BallButton instance = null;		//①空箱
    [Header("ボールスピード")] public float ballSpeed;
    [Header("加算するキック力")] public float myBall;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;
    [Header("加算するキック力の上限")] public float endBall;

    public float highBall; //キック力用変数
    private string key = "HIGH KICK"; //キック力の保存先キー
    public Text highBallText; //キック力を表示するText
    private Text ballText = null;
    private bool hs = true;
    private float oldBall = 2;

    public GameObject soccerBall;
    private ObjectCollision oc;
    private PlayerC sc;

    private Player pl;
    private CircleCollider2D col;

    public bool on = false;
    public string PlayerTag = "Player";



    [HideInInspector] public bool isOnD = false;
    [HideInInspector] public bool isOnE = false;
    [HideInInspector] public float ySpeed;
    [HideInInspector] public bool isSpace = false;
    //[HideInInspector] public bool baundo = false;


    //private float jumpPos = 0.0f;
    private bool jjj;

    private void Awake()						//②Startによく似たメソッド
    {
        if (instance == null)						//③もしスタティックな変数が空箱だった場合
        {
            instance = this;						//このインスタンスのアドレスを入れる　空箱の中に中身を入れることができた
            //DontDestroyOnLoad(this.gameObject);	//④このスクリプト(GManager)が張り付いているゲームオブジェクトはシーン移動で破棄されない
        }
        else									//⑤すでにインスタンスが存在する場合
        {
            //Destroy(this.gameObject);				//このゲームオブジェクトを破棄するようにする
        }
    }

    void Start()
    {
        highBall = PlayerPrefs.GetFloat(key, 2.0001f);
        //保存しておいたキック力をキーで呼び出し取得し保存されていなければ2.0001fになる

        highBallText.text = highBall.ToString();
        ballText = GetComponent<Text>();

        ballSpeed = highBall;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn & hs)
        {
            if (Player.instance != null)
            {
                if (endBall > highBall)
                {
                    ballSpeed += myBall;
                    oldBall = ballSpeed;
                }
                else
                    hs = false;
            }
            //現在のキック力より過去のキック力が高い時
            if (oldBall > highBall & hs)
            {
                highBall = oldBall;
                //キック力更新

                PlayerPrefs.SetFloat(key, highBall);
                //キック力を保存

                highBallText.text = "KICK UP" + highBall.ToString();
                //キック力を表示
                hs = false;
            }
        }
        if (Input.GetKey(KeyCode.Space) && !isSpace)
        //if (CrossPlatformInputManager.GetButtonDown("bb"))
        {
            isSpace = true;
            OnClick();
            //Debug.Log("スペースキー押下" + isSpace);
        }
    }

    // ボタンが押された場合、今回呼び出される関数
    public void OnClick()
    {
        Invoke("Cancel2", 1);
        GameObject search = GameObject.Find("soccerBall2");
        bool n = search;
        //Debug.Log("サッカーボール２サーチ" + n);

        if (n == true)
        {
            //Debug.Log("はいったよ" + n);
            sc = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
            //Debug.Log("sc" + sc);
            pl = GameObject.Find("Player").GetComponent<Player>();
            //Debug.Log("pl" + pl);
            //Debug.Log("はいったよyoyoyoyoyoysc.isOn" + sc.isOn);
            //Debug.Log("はいったよyoyoyoyoyoysc.isSb" + sc.isSb);
            if (sc.isOn || sc.isSb)
            {
                ySpeed = 0.11f;
                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(8 * Time.deltaTime, ySpeed, 0);

                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0.05f, 0);
                on = true;
                //Debug.Log("はいったよsc.isOn" + sc.isOn);



            }
            else if (sc.isPlayerExit)
            {
                // 移動させたいオブジェクトを取得
                GameObject obj = GameObject.Find("soccerBall2");
                //pl.bcs2.isTrigger = true;
                float jumpPos = obj.transform.position.y; //ジャンプした位置を記録する
                //Debug.Log("jumpPos；" + jumpPos);

                // オブジェクトを移動
                obj.transform.localPosition += new Vector3(ballSpeed * Time.deltaTime, ySpeed, 0);
                //0秒後にCall関数を実行し、その後は0秒間隔で実行し続ける
                InvokeRepeating("OnClick", 0, 0);
                isOnD = true;

                if (sc.isOnC && isOnD && sc.isGround)
                {
                    GameObject ob = GameObject.Find("soccerBall2");
                    float jump = ob.transform.position.y; //ジャンプした位置を記録する
                    //Debug.Log("jump；" + jump);
                    //現在の高さが飛べる高さより下か
                    jjj = jump > jumpPos + 0.1f;
                    //Debug.Log("jjj；" + jjj);
                    if (jjj)
                    {
                        isOnE = true;
                        //Debug.Log("jjj2：" + jjj); 
                    }
                }
                //Invokeを止める
                Invoke("Cancel", 1);
            }
            n = false;
            return;
        }
        else
        {
            isSpace = false;
            //Debug.Log("isSpace" + isSpace);
        }
    }

    void Cancel()
    {
        //Invokeで実行しているOnClick関数を1秒後に停止する
        CancelInvoke("OnClick");
        //関数名を記述しなければInvoke系全てを停止する
        //CancelInvoke();
        sc.breft = false;
        sc.isPlayerExit = false;
        sc.isOnC = false;
        //sc.blight = false;
        //Debug.Log("sc.breft void Cancel()；" + sc.breft);
        pl.hd = false;

        on = false;
        isOnD = false;
        if (sc.isSbExit == true)
        {
            // 移動させたいオブジェクトを取得
            GameObject obj = GameObject.Find("soccerBall2");
            obj.gameObject.transform.parent = null;
            obj.transform.localScale = new Vector3(1, 1, 1);
            // = true;
            //Debug.Log("バウンド" + baundo);
        }
        ballSpeed = highBall;
        ySpeed = 0.1f;

    }
    void Cancel2()
    {
        if (isSpace)
        {
            isSpace = false;
            //Debug.Log("キャンセル２" + isSpace);
        }
    }
}