using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ball : MonoBehaviour
{
    public static ball instance = null;		//①空箱
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
   
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    #endregion


    #region//プライベート変数
    
    private Rigidbody2D rb = null;
    private CircleCollider2D capcol = null;
    private SpriteRenderer sr = null;
    private MoveObject moveObj = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    public bool isRun = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    
    private bool isClearMotion = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float otherJumpSpeed = 0.0f;
    public float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private string enemyTag = "Enemy";
    //private string deadAreaTag = "DeadArea";
    //private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string jumpStepTag = "JumpStep";
    #endregion

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
        //コンポーネントのインスタンスを捕まえる
        
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isContinue)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                sr.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                sr.enabled = false;
            }
            //明滅　ついているとき
            else
            {
                sr.enabled = true;
            }
            //1秒たったら明滅終わり
            if (continueTime > 1.0f)
            {
                isContinue = false;
                blinkTime = 0.0f;
                continueTime = 0.0f;
                sr.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                continueTime += Time.deltaTime;
            }
        }
    }



    void FixedUpdate()
    {

        if (!isDown && !GManager.instance.isGameOver && !GManager.instance.isStageClear)
        {
            

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            

            //移動速度を設定
            Vector2 addVelocity = Vector2.zero;
            if (moveObj != null)
            {
                addVelocity = moveObj.GetVelocity();
            }
            rb.velocity = new Vector2(xSpeed, ySpeed) + addVelocity;
        }
        else
        {
            if (!isClearMotion && GManager.instance.isStageClear)
            {
                
                isClearMotion = true;
            }
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    /// <summary>
    /// Y成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>Y軸の速さ</returns>
    private float GetYSpeed()
    {
        float verticalKey = CrossPlatformInputManager.GetAxis("Vertical");
        float ySpeed = -gravity;

        if (CrossPlatformInputManager.GetButtonDown("bb"))
        {
            
            //Debug.Log("Fire1");
        }

        //何かを踏んだ際のジャンプ
        if (isOtherJump)
        {
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = otherJumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        //地面にいるとき
        else if (isGround)
        {
            if (verticalKey > 0)
            {
                if (!isJump)
                {
                    GManager.instance.PlaySE(jumpSE);
                }
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        //ジャンプ中
        else if (isJump)
        {
            //上方向キーを押しているか
            bool pushUpKey = verticalKey > 0;
            //現在の高さが飛べる高さより下か
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //ジャンプ時間が長くなりすぎてないか
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump || isOtherJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }
        return ySpeed;
    }


    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    public float GetXSpeed()
    {
        float horizontalKey = CrossPlatformInputManager.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRun = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isRun = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //前回の入力からダッシュの反転を判断して速度を変える
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    

    

    

    

   

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);
        bool jumpStep = (collision.collider.tag == jumpStepTag);

        if (enemy || moveFloor || fallFloor || jumpStep)
        {
            foreach (ContactPoint2D p in collision.contacts)
            {
                    if (enemy || fallFloor || jumpStep)
                    {
                        ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                        if (o != null)
                        {
                            if (enemy || jumpStep)
                            {
                                otherJumpHeight = o.boundHeight;    //踏んづけたものから跳ねる高さを取得する
                                otherJumpSpeed = o.jumpSpeed; //ジャンプするスピード
                                o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                                jumpPos = transform.position.y; //ジャンプした位置を記録する
                                isOtherJump = true;
                                isJump = false;
                                jumpTime = 0.0f;
                            }
                            else if (fallFloor)
                            {
                                o.playerStepOn = true;
                            }
                        }
                        else
                        {
                            Debug.Log("ObjectCollisionが付いてないよ!");
                        }
                    }
                    else if (moveFloor)
                    {
                        moveObj = collision.gameObject.GetComponent<MoveObject>();
                    }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == moveFloorTag)
        {
            //動く床から離れた
            moveObj = null;
        }
    }

    
    #endregion
}
