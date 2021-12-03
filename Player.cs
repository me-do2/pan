using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public static Player instance = null;		//①空箱
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプする長さ")] public float jumpLimitTime;
    [Header("接地判定")] public GroundCheck ground;
    [Header("天井判定")] public GroundCheck head;
    [Header("ダッシュの速さ表現")] public AnimationCurve dashCurve;
    [Header("ジャンプの速さ表現")] public AnimationCurve jumpCurve;
    [Header("踏みつけ判定の高さの割合(%)")] public float stepOnRate;
    [Header("ジャンプする時に鳴らすSE")] public AudioClip jumpSE;
    [Header("やられた鳴らすSE")] public AudioClip downSE;
    [Header("コンティニュー時に鳴らすSE")] public AudioClip continueSE;
    [Header("ケリする時に鳴らすSE")] public AudioClip keriSE;
    [Header("ヘディングする時に鳴らすSE")] public AudioClip headingSE;
    [Header("メイン")] public Main mainJoy;
    [Header("左ボタン確認")] public GameObject LeftButton;
    [Header("ジョイスティック")] public GameObject Vjoystick;
    [Header("ボールボタン")] public GameObject BallButton2;
    #endregion


    #region//プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private MoveObject moveObj = null;
    [HideInInspector] public SpriteRenderer sr = null;
    [HideInInspector] public bool isGround = false;
    [HideInInspector] public bool isJump = false;
    [HideInInspector] public bool isKeri = false;
    [HideInInspector] public bool isHeading = false;
    [HideInInspector] public bool hd = false;
    [HideInInspector] public bool downPan = false;
    private bool isHead = false;
    private bool isRun = false;
    private bool ke = false;
    private bool isSlide = false;
    private PlayerC ss;
    //public BoxCollider2D bcs2 = null;
    private GroundCheck glc;
    [HideInInspector] public bool isDown = false;
    private bool isOtherJump = false;
    private bool isContinue = false;
    private bool nonDownAnim = false;
    private bool isClearMotion = false;
    private bool olsc = false;
    private bool LButton = false; 
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float otherJumpSpeed = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private float continueTime = 0.0f;
    private float blinkTime = 0.0f;
    private float headingO = 0.0f;
    private float scaleXYZ = 1.0f;
    private float span = 0.1f;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private string hitAreaTag = "HitArea";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string jumpStepTag = "JumpStep";
    private string warpDoorTag = "WarpDoor";
    

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
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        ss = GetComponent<PlayerC>();
        //bcs2 = GetComponent<BoxCollider2D>();
        ke = true;


        //Debug.Log("JumpButton:  " + JumpButton.activeSelf);//インスペクター確認
        LButton = (LeftButton.activeSelf);
        if (!LButton)
        {
            Vjoystick.SetActive(false);
            BallButton2.SetActive(true);
        }
        else if (LButton)
        {
            Vjoystick.SetActive(true);
            BallButton2.SetActive(false);
        }

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
            //1.2秒たったら明滅終わり
            if (continueTime > 1.2f)
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
            //接地判定を得る
            isGround = ground.IsGround();
            isHead = head.IsGround();

            //各種座標軸の速度を求める
            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            //アニメーションを適用
            SetAnimation();

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
                anim.Play("player_win");
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

        //if (Input.GetKey(KeyCode.Space))
        

       
        if (CrossPlatformInputManager.GetButtonDown("bb") || Input.GetKey(KeyCode.Space))
        {
            GameObject search = GameObject.Find("soccerBall2");
            bool n = (bool)search;
            
           
            if (n == true)
            {
                //Debug.Log("はいったよプレイヤーのほう" + n);
                //jumpPos = transform.position.y; //ジャンプした位置を記録する
                headingO = jumpPos + 3;
                bool heading1 = headingO < transform.position.y;//現在の高さが３より上なら
                //Debug.Log("heading1   " + heading1);

                ss = GameObject.Find("soccerBall2").GetComponent<PlayerC>();
                //bcs2 = GameObject.Find("soccerBall2").GetComponent<BoxCollider2D>();
                glc = GameObject.Find("soccerBall2").GetComponent<GroundCheck>();
                //Debug.Log("ss" + ss);
                if (ss.isOn && !heading1)
                {
                    //Debug.Log("ss.isOnプレイヤー" + ss.isOn);
                    anim.Play("player_keri");
                    GManager.instance.PlaySE(keriSE);
                    //bcs2.isTrigger = false;
                    glc.checkPlatformGroud = false;
                    isKeri = true;
                    ke = false;
                    //Debug.Log("ケリアニメーション発動");
                }
                else if (ss.isOn && heading1)
                {
                    anim.Play("player_heading");
                    GManager.instance.PlaySE(headingSE);
                    isHeading = true;
                    hd = true;

                    InvokeRepeating("Logging", span, span);

                    //scaleXYZ += Time.deltaTime;
                    //ss.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);

                    //ss.transform.localScale = new Vector3(3, 3, 3);
                    //Debug.Log("ヘディングアニメーション発動");
                   

                }
                else if (!isKeri && ss.isSbExit && !hd && !heading1)
                {
                    anim.Play("player_slide");
                    isSlide = true;
                    //Debug.Log("スライディングアニメーション発動");
                }
                
                    //Debug.Log("まだサッカーボールと出会ってないよ");
                n = false;
            }
            
            else if (ke && !hd)
            {
                anim.Play("player_slide");
                isSlide = true;
                ke = false;
                //Debug.Log("スライディングアニメーション発動20");
            }
            
        }
        if (isKeri && anim != null)
        {
            //keriアニメーションが完了しているかどうか
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_keri"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    isKeri = false;
                    //bcs2.isTrigger = true;
                    glc.checkPlatformGroud = true;
                    //Debug.Log("ケリアニメーション完了");
                }
            }
        }
        if (isSlide && anim != null)
        {
            //Slideアニメーションが完了しているかどうか
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_slide"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    isSlide = false;
                    ke = true;
                    //Debug.Log("スライディングアニメーション完了");

                }
            }
        }
        if (isHeading && anim != null)
        {
            //ヘディングアニメーションが完了しているかどうか
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_heading"))
            {
                //Debug.Log("ヘデ" + currentState.normalizedTime);
                if (currentState.normalizedTime >= 1)
                {
                    //Debug.Log("ヘディング" + currentState.normalizedTime);
                    isHeading = false;
                    
                    //Debug.Log("ヘディングアニメーション完了");
                    //Invokeを止める
                    CancelInvoke("Logging");
                    scaleXYZ = 1.0f;
                }
            }
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

    void Logging()
    {
        if (ss != null)
        {
            if (olsc)
            {
                // 3以上にならないようにする
                if (scaleXYZ >= 3.0f)
                {
                    scaleXYZ = 3.0f;
                }
                olsc = false;
                scaleXYZ += 0.1f;
                ss.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            }
            else
            olsc = true;
            scaleXYZ += 0.1f;
            ss.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            //Debug.LogFormat("{0}秒経過", span);
            // 3以上にならないようにする
            if (scaleXYZ >= 3.0f)
            {
                scaleXYZ = 3.0f;
            }
        }
        else
        {
            isHeading = false;
            //Invokeを止める
            CancelInvoke("Logging");
            scaleXYZ = 1.0f;
            Debug.Log("アンパンマン新しい顔よ");
        }
    }

    /// <summary>
    /// X成分で必要な計算をし、速度を返す。
    /// </summary>
    /// <returns>X軸の速さ</returns>
    public float GetXSpeed()
    {
        float horizontalKey = CrossPlatformInputManager.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        LButton = (LeftButton.activeSelf);

        if (LButton)
        {
            if (mainJoy.isUsiro)
            {
                //Debug.Log("mainJoy.isUsiro    " + mainJoy.isUsiro);
                if (horizontalKey < 0 && !isKeri || mainJoy.ATButton.axisValue < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    isRun = true;
                    dashTime += Time.deltaTime;
                    xSpeed = -speed;
                    mainJoy.isMae = false;
                    //Debug.Log("xSpeed.isUsiro    " + xSpeed);
                }
            }
            else if (mainJoy.isMae)
            {
                //Debug.Log("mainJoy.isMae    " + mainJoy.isMae);
                if (horizontalKey > 0 && !isKeri || mainJoy.ATButton.axisValue > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    isRun = true;
                    dashTime += Time.deltaTime;
                    xSpeed = speed;
                    mainJoy.isUsiro = false;
                    //Debug.Log("xSpeed.isMae    " + xSpeed);
                }
            }
            else if (mainJoy.joystick.Horizontal == 0)
            {
                isRun = false;
                mainJoy.isUsiro = false;
                mainJoy.isMae = false;
                xSpeed = 0.0f;
                dashTime = 0.0f;
                //Debug.Log("xSpeed.0    " + xSpeed);
            }
        }
        else
        {
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

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("run", isRun);
        anim.SetBool("keri", isKeri);
        anim.SetBool("slide", isSlide);
        anim.SetBool("heading", isHeading);
    }

    /// <summary>
    /// コンティニュー待機状態か
    /// </summary>
    /// <returns></returns>
    public bool IsContinueWaiting()
    {
        if (GManager.instance.isGameOver)
        {
            return false;
        }
        else
        {
            return IsDownAnimEnd() || nonDownAnim;
        }
    }

    //ダウンアニメーションが完了しているかどうか
    private bool IsDownAnimEnd()
    {
        if (isDown && anim != null)
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("player_down"))
            {
                if (currentState.normalizedTime >= 1)
                {
                    downPan = false;
                    return true;
                }
            }
        }
        return false;
    }

    


    /// <summary>
    /// コンティニューする
    /// </summary>
    public void ContinuePlayer()
    {
        GManager.instance.PlaySE(continueSE);
        isDown = false;
        anim.Play("player_stand");
        isJump = false;
        isOtherJump = false;
        isRun = false;
        isKeri = false;
        isSlide = false;
        isHeading = false;
        ke = true;
        isContinue = true;
        nonDownAnim = false;
    }

    //やられた時の処理
    private void ReceiveDamage(bool downAnim)
    {
        if (isDown || GManager.instance.isStageClear)
        {
            return;
        }
        else
        {
            if (downAnim)
            {
                downPan = true;
                anim.Play("player_down");
            }
            else
            {
                nonDownAnim = true;
            }
            isDown = true;
            GManager.instance.PlaySE(downSE);
            GManager.instance.SubHeartNum();
        }
    }

    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool enemy = (collision.collider.tag == enemyTag);
        bool moveFloor = (collision.collider.tag == moveFloorTag);
        bool fallFloor = (collision.collider.tag == fallFloorTag);
        bool jumpStep = (collision.collider.tag == jumpStepTag);
        bool warpDoor = (collision.collider.tag == warpDoorTag);
        bool hitArea = (collision.collider.tag == hitAreaTag);

        if (enemy || moveFloor || fallFloor || jumpStep || warpDoor || hitArea)
        {
            //踏みつけ判定になる高さ
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));

            //踏みつけ判定のワールド座標
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    if (enemy || fallFloor || jumpStep || warpDoor)
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
                            else if (fallFloor || warpDoor)
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
                else
                {
                    if (enemy)
                    {
                        if (isSlide)
                        {
                            ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                            o.playerStepOn = true;        //踏んづけたものに対して踏んづけた事を通知する
                        }
                        else
                        ReceiveDamage(true);
                        break;
                    }
                    else if (hitArea)
                    {
                        ReceiveDamage(true);
                    }
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
        if (collision.collider.tag == warpDoorTag)
        {
            //ワープドアから離れた
            ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
            o.playerStepOn = false;
            //Debug.Log("ワープドアから離れた");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            ReceiveDamage(false);
        }
        else if (collision.tag == hitAreaTag)
        {
            ReceiveDamage(true);
        }
    }
    #endregion
}
