using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerC : MonoBehaviour
{
    public static PlayerC instance = null;		//①空箱
    [HideInInspector] public CircleCollider2D col = null;
    private Rigidbody2D physics = null;
    private BallButton bb = null;
    private float highSpeed; //ハイスピード用変数
    private string key = "HIGH SPEED"; //ハイスピードの保存先キー

    [HideInInspector] public bool isSb = false;
    [HideInInspector] public bool isSbEnter, isSbStay, isSbExit;	//②3つのフラグを作成する

    /// <summary>
    /// 判定内にプレイヤーがいる
    /// </summary>
    [HideInInspector] public bool isOn = false;
    [HideInInspector] public bool isPlayerExit = false;

    private Player pl;
    private ball bl;
    public GameObject Player;
    public string PlayerTag = "Player";

    //private string key2 = "HIGH KICK"; //キック力の保存先キー
    //private float highKick; //キック力用変数
    [HideInInspector] public bool isOnC = false;
    [Header("接地判定")] public GroundCheck ground;
    [HideInInspector] public bool isGround = false;
    [HideInInspector] public bool breft = false;
    [HideInInspector] public bool blight = false;
    [HideInInspector] public bool a = false;
    [HideInInspector] public bool b = false;
    [HideInInspector] public bool tomero = false;

    // 2Dリジッドボディ
    Rigidbody2D rb2D;

    void Start()
    {
        // ここで2Dリジッドボディを受け取る。
        rb2D = GetComponent<Rigidbody2D>();
        bb = GetComponent<BallButton>();
    }

    public bool IsSb()								//⑥プレイヤーのスクリプトから読めるようにpublicでメソッドを書いていく　返り値として地面にちゃんと設置しているかを返す
    {
        if (isSbEnter || isSbStay)					//⑦EnterもしくはStayを通っていた場合、接地判定をtrueにする
        {
            isSb = true;
            //Physics Material2Dを取得
            //var material = GetComponent<Rigidbody2D>().sharedMaterial;
            //material.friction = 0.1f;
            //material.bounciness = 0.0f;
        }
        else if (isSbExit)							//⑧Exitを通っていた場合、接地判定をfalseにする　Exitを通っていた場合でもEnterかStayが呼ばれたら、地面に着いているとみなす
        {											//またelse文が無い為、どのメソッドも通っていない場合、isGround(接地判定フラグ)はそのままとなる
            isSb = false;							//キャラクターがしばらく止まるなどしてStayが呼ばれない状態となったとしても対応できる
        }
        isSbEnter = false;							//⑨呼び出されたら各種フラグをfalseにして元の状態に戻す
        isSbStay = false;
        isSbExit = false;
        return isSb;								//⑩接地判定を返す
    }

    #region//接触判定
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag(PlayerTag))
        {
           isOn = true;
           isSbStay = true;
           this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
           //Debug.Log("プレイヤーが判定に入り続けています" + isOn);
            
           pl = GameObject.Find("Player").GetComponent<Player>();

           if (pl.isJump == true)
           {
               this.gameObject.transform.parent = col.gameObject.transform; //プレイヤーを親要素に設定
               this.transform.localPosition = new Vector3(1f, -0.7f, 0.0f); // 座標を変更
               //Debug.Log("プレイヤーがジャンプ");
               bl = GameObject.Find("soccerBall2").GetComponent<ball>();
               highSpeed = PlayerPrefs.GetFloat(key, 3.0001f);
               //保存しておいたハイスピードをキーで呼び出し取得し保存されていなければ5になる
               bl.speed = highSpeed;
               //Debug.Log("ジャンプ中のボールスピード" + bl.speed);
            }
            var gameObject = GameObject.Find("soccerBall2");
            if (gameObject == true && pl.isGround == true)
            {
               bl = GameObject.Find("soccerBall2").GetComponent<ball>();
               bl.speed = 0;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag(PlayerTag))
        {
            isOn = false;
            isPlayerExit = true;
            isSbExit = true;                            //⑤それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）
            bl = GameObject.Find("soccerBall2").GetComponent<ball>();
            bl.speed = 0;
            //Debug.Log("プレイヤーが判定を出ました" + isOn);

            Vector3 scale = col.transform.localScale;//Scale(スケール情報にアクセス)
            float aaa = scale.x;//パンちゃんの拡大/縮小のxを見る
            //Debug.Log("プレイヤーaaa" + aaa);
            if (aaa == -1.0)
            {
                Invoke("Hoge", 1);
            }
            else if (aaa == 1.0)
            {
                Invoke("Hoge", 0);
            }
        }
    }

    void Hoge()
    {
        GameObject obj = GameObject.Find("soccerBall2");
        obj.gameObject.transform.parent = null;
        //Debug.Log("1秒後に離縁された");
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(PlayerTag))
        {
            isOn = true;
            isSbEnter = true;							//③それぞれのフラグをそれぞれのメソッドでtrueにする（trueになったらこのメソッドを通ったとみなす）							
            //Debug.Log("プレイヤーが判定に入りました" + isOn);
        }
    }
    #endregion

    public void Awake()
    {
        this.physics = this.GetComponent<Rigidbody2D>();
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

    void FixedUpdate()
    {
        if (breft)
        {
            bl = GameObject.Find("soccerBall2").GetComponent<ball>();
            float xSpeed = bl.GetXSpeed();
            bl.isRun = true;
            bl.dashTime += Time.deltaTime;
            xSpeed = -1;

            GameObject ob = GameObject.Find("soccerBall2");
            ob.transform.localPosition += new Vector3(2 * Time.deltaTime, 0.1f, 0);
            //Debug.Log("breft" +breft);

            if(bl.isRun && !tomero)
            {
                Invoke("Hoge2", 3);//3秒後にvoid Hoge2()を実行する
            }
        }
        else
        {
            //Debug.Log("あせるでない");
        }
    }

    void Update()
    {
        //接地判定を得る
        isGround = ground.IsGround();
        //Debug.Log("isGroundサッカーボール" + isGround);
        //bb = GameObject.Find("BallButton").GetComponent<BallButton>();
        //if (bb.on)
        //{
            //Physics Material2Dを取得
            //var material = GetComponent<Rigidbody2D>().sharedMaterial;
            //material.friction = 0.0f;
            //material.bounciness = 0.0f;
        //}
        //else if (isGround)
        //{
            //bb = GameObject.Find("BallButton").GetComponent<BallButton>();
            //if (bb.baundo)
            //{
                //Physics Material2Dを取得
                //var material = GetComponent<Rigidbody2D>().sharedMaterial;
                //material.friction = 0.0f;
                //material.bounciness = 0.0f;
                //bb.baundo = false;
                //Invoke("Hoge4", 1);
            //}
        //}
        //else
        //{
           // Debug.Log("あせるでない2");
        //}
    }

    void Hoge2()
    {
        if (!tomero)
        {
            tomero = true;
            breft = false;
            //Debug.Log("Hoge2 breft" + breft);
            Invoke("Hoge3", 1);//1秒後にvoid Hoge3()を実行する
        }
    }

    void Hoge3()
    {
        if (tomero)
        {
            tomero = false;
            //Debug.Log("Hoge3 tomero" + tomero);
        }
    }

    //void Hoge4()
    //{
        //Physics Material2Dを取得
        //var material = GetComponent<Rigidbody2D>().sharedMaterial;
        //material.friction = 0.1f;
        //material.bounciness = 0.0f;
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        isOnC = true;
        //Debug.Log("Hit"); // ログを表示する

        GameObject search = GameObject.Find("soccerBall2");
        bool n = (bool)search;
        GameObject sear = GameObject.Find("BallButton");
        bool m = (bool)sear;

        if (n == true && m == true)
        {
            bb = GameObject.Find("BallButton").GetComponent<BallButton>();
            pl = GameObject.Find("Player").GetComponent<Player>();
            if (bb.isOnE && pl.isKeri || pl.isHeading)
            {
                //Debug.Log("0にした");
                bb.ballSpeed = 0;
                bb.ySpeed = 0;

                // transformを取得
                GameObject obj = GameObject.Find("soccerBall2");
                obj.gameObject.transform.parent = null;//離縁

                Transform myTransform = obj.transform;
                // ローカル座標を基準にした、サイズを取得
                Vector3 localScale = myTransform.localScale;

                // transformを取得
                GameObject pobj = GameObject.Find("Player");
                Transform myT = pobj.transform;
                // ローカル座標を基準にした、サイズを取得
                Vector3 localS = myT.localScale;
                if (!breft && localS.x > 0.9)// 右方向に動いている
                {
                    GameObject ob = GameObject.Find("soccerBall2");
                    ob.transform.localScale = new Vector3(-1, 1, 1);
                    bl = GameObject.Find("soccerBall2").GetComponent<ball>();
                    float xSpeed = bl.GetXSpeed();
                    bl.isRun = true;
                    bl.dashTime += Time.deltaTime;
                    xSpeed = -1;

                    // オブジェクトを移動
                    ob.transform.localPosition += new Vector3(2.0f * Time.deltaTime, 0.1f, 0);
                    breft = true;
                    //Debug.Log("ボールが左に反転したよ２");
                }

                if (!breft && localS.x == -1)// 左方向に動いている
                {
                    localScale.x = 1;  // 反転
                    myTransform.localScale = localScale;// 更新
                    
                    GameObject ob = GameObject.Find("soccerBall2");
                    // オブジェクトを移動
                    ob.transform.localPosition += new Vector3(2 * Time.deltaTime, 0.1f, 0);
                    breft = true;
                    ////Debug.Log("ボールが右に反転したよ２");
                }
            }
        }
        else
        {
            //Debug.Log(false);
        }
    }
}  
