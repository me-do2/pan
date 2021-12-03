using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy_Gunner : MonoBehaviour
{
    [Header("加算スコア")] public int myScore;
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;
    [Header("重力")] public float gravity;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("モブスク")] public mob_AI aiai;
    [Header("Bombスクリプト")] public Enemy_Bomb eBomb;
    [Header("プレイヤー")] public GameObject target;
    [Header("ワープドア")] public GameObject WarpDoor;
    [Header("シールドオブジェクト")] public GameObject shieldObj;
    [Header("ビームオブジェクト")] public GameObject beamObj;
    [Header("ライトオブジェクト")] public GameObject lightObj;
    [Header("ライトオブジェクト上")] public GameObject lightObj_ue;
    [Header("ライトオブジェクト下")] public GameObject lightObj_sita;
    [Header("ムーブフロア")] public GameObject moveFloor;
    [Header("ドア")] public GameObject ExDoor;
    [Header("シールドSE")] public AudioClip ShieldSE;
    [Header("ダメージSE")] public AudioClip DamageSE;
    [Header("デスSE")] public AudioClip DeathSE;
    [Header("オープニングSE")] public AudioClip OpeningSE;
    [Header("ビームSE")] public AudioClip BeamSE;
    [Header("ライトニングSE")] public AudioClip LightningSE;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [HideInInspector] public bool isAttack = false;
    [HideInInspector] public bool Attt = false;
    [HideInInspector] public bool Bttt = false;
    [HideInInspector] public bool Cttt = false;
    [HideInInspector] public bool Ettt = false;
    [HideInInspector] public bool Fttt = false;
    [HideInInspector] public bool isDead = false;						
    [HideInInspector] public bool isBeam = false;
    [HideInInspector] public bool isBeamEnd = false;
    [HideInInspector] public bool isLight = false;
    [HideInInspector] public bool isDamageee = false;
    [HideInInspector] public bool isCharacter = false;
    [HideInInspector] public bool isBeammm = false;
    [HideInInspector] public bool isMuki180 = false;
    [HideInInspector] public bool isLightooo = false;
    [HideInInspector] public bool bossnikamera = false;
    [HideInInspector] public bool nikaifumareta = false;
    [HideInInspector] public bool cameraDooon = false;
    [HideInInspector] public bool bossiti = false;
    [HideInInspector] public bool isOpening = false;
    [HideInInspector] public bool isMoudame = false;

    private Rigidbody2D rb;
    private Animator anim;
    private ObjectCollision oc;
    private PolygonCollider2D col = null;
    private SpriteRenderer sr = null;
    private int damageeee = 0;
    private float timer;
    private float tenmetuTime = 0.0f;
    private float blinkTime = 0.0f;
    private bool isDamage = false;
    private bool isTenmetu = false;
    private bool isFumareta = false;
    private float scaleXYZ = 1.0f;
    private float span = 0.05f;
    private float scaleX = 2.0f;
    private float span2 = 0.01f;
    private BossState nowState = BossState.StartEnsyutu;

    private enum BossState  //←「BossState」の部分はenumの名前（自分で定義する）
    {
        StartEnsyutu,  //←好きなように名前をつけることができる
        Battle,
        ClearEnsyutu,
    }

    void Start()
    {
        nowState = BossState.StartEnsyutu;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();			
        col = GetComponent<PolygonCollider2D>();			
        sr = GetComponent<SpriteRenderer>();

        if (anim == null || attackObj == null)
        {
            Debug.Log("設定が足りません");
            Destroy(this.gameObject);
        }
        else
        {
            attackObj.SetActive(false);
        }
    }

    

    void FixedUpdate()
    {
        //アニメーションを適用
        SetAnimation();
    }

    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("beam", isBeam);
        anim.SetBool("light", isLight);
        anim.SetBool("damage", isDamageee);
        anim.SetBool("character", isCharacter);
    }

    private void Update()
    {
        switch(nowState)  //←nowStateには現在の状態が入っている
        {
            case BossState.StartEnsyutu:
                //登場演出時の処理を書く
                if (!isOpening)
                {
                    isOpening = true;
                    GManager.instance.PlaySE(OpeningSE);
                    this.transform.localPosition = new Vector3(118.44f, 329.0f, 0.0f);
                    Animator animD = ExDoor.GetComponent<Animator>();
                    animD.SetTrigger("on");

                    isCharacter = true;
                    anim.Play("character");
                }
            
                else if (isCharacter && anim != null)
                {
                    //Slideアニメーションが完了しているかどうか
                    AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
                    if (currentState.IsName("character"))
                    {
                        if (currentState.normalizedTime >= 0.95)
                        {
                            Debug.Log("オープニングアニメーション完11111" + currentState.normalizedTime);
                            isCharacter = false;
                            nowState = BossState.Battle;
                            Invoke("Logging14", 3);
                            Debug.Log("オープニングアニメーション完了" + nowState);
                        }
                    }
                }
                break;

            case BossState.Battle:
                //戦闘中の処理を書く
                if (!bossiti)
                {
                    bossiti = true;
                    this.transform.localPosition = new Vector3(115.0f, 329.0f, 0.0f);
                }

                var gameObject = GameObject.Find("WarpExit_9");
                if (gameObject == true)
                {
                    GameObject.Destroy(gameObject);
                }
                moveFloor.SetActive(true);
                // リジッドボディ2Dの位置と回転のチェックを外す
                rb.constraints = RigidbodyConstraints2D.None;
                // リジッドボディ2Dの回転Zにチェックを付ける
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //ボスのトランスフォームの親をフロアにする
                this.transform.parent = moveFloor.transform;

                Vector3 scale = target.transform.localScale;//Scale(スケール情報にアクセス)
                float aaa = scale.x;//パンちゃんの拡大/縮小のxを見る
                if (aaa == -1.0)
                {
                    Quaternion direction = transform.rotation;
                    transform.rotation = target.transform.rotation;
                    transform.rotation = Quaternion.identity; // ワールド座標の正面
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Y軸に180°回転
                    moveFloor.transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Y軸に180°回転
                    transform.eulerAngles = new Vector3(0f, 180f, 0f); // 同上
                    moveFloor.transform.eulerAngles = new Vector3(0f, 180f, 0f); // 同上
                    isMuki180 = true;
                }
                else if (aaa == 1.0)
                {
                    Quaternion direction = transform.rotation;
                    transform.rotation = target.transform.rotation;
                    transform.rotation = Quaternion.identity; // ワールド座標の正面
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Y軸に0°回転
                    moveFloor.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Y軸に0°回転
                    transform.eulerAngles = new Vector3(0f, 0f, 0f); // 同上
                    moveFloor.transform.eulerAngles = new Vector3(0f, 0f, 0f); // 同上
                    target.transform.rotation = Quaternion.Euler(0, 0, 0);
                    isMuki180 = false;
                }

                if (!oc.playerStepOn)                           //⑧橋渡しするスクリプトからプレイヤーに踏まれたかどうか
                {
                    if (sr.isVisible || nonVisibleAct)
                    {
                        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

                        //通常の状態
                        if (currentState.IsName("idle"))
                        {
                            if (timer > interval)
                            {
                                anim.SetTrigger("attack");
                                timer = 0.0f;
                                isAttack = true;
                                //Debug.Log("isAttack1" + isAttack);
                            }
                            else
                            {
                                timer += Time.deltaTime;
                            }
                        }
                    }
                }
                else
                {
                    if (!isDead)
                    {
                        isDamage = true;
                        isTenmetu = true;

                        if (isDamage && !isFumareta)
                        {
                            damageeee += 1;
                            Debug.Log("踏まれた" + damageeee);

                            if (!nikaifumareta)
                            {
                                isDamage = false;
                                isFumareta = true;
                                isDamageee = true;
                                anim.Play("damage");
                                GManager.instance.PlaySE(DamageSE);
                                Invoke("Logging3", 3);
                            }
                        }

                        if (isTenmetu && !nikaifumareta)
                        {
                            //明滅　ついている時の戻る			
                            if (blinkTime > 0.2f)
                            {
                                sr.enabled = true;
                                blinkTime = 0.0f;
                            }
                            else if (blinkTime > 0.1f)
                            {
                                sr.enabled = false;
                            }
                            else
                            {
                                sr.enabled = true;
                            }
                            //3.1秒たったら明滅終わり
                            if (tenmetuTime > 3.1f)
                            {
                                isTenmetu = false;
                                oc.playerStepOn = false;
                                blinkTime = 0.0f;
                                tenmetuTime = 0.0f;
                                sr.enabled = true;
                            }
                            else
                            {
                                blinkTime += Time.deltaTime;  //演出中は演出用の時間を進める
                                tenmetuTime += Time.deltaTime;
                            }
                        }

                        if (damageeee == 1 && !isDamageee && !isBeamEnd)
                        {
                            isBeam = true;
                            if (isBeam)
                            {
                                anim.Play("BeamAttack");
                                
                                Invoke("Logging4", 3);

                                shieldObj.SetActive(true);
                                GManager.instance.PlaySE(ShieldSE);
                                InvokeRepeating("Logging6", span, span);
                                Invoke("Logging7", 1);//1秒後にvoid Logging7()を実行する
                            }
                        }

                        else if (damageeee == 2 && !isDamageee && !isLight　&& !isTenmetu)
                        {
                            isLight = true;
                            if (isLight)
                            {
                                anim.Play("LightningAttack");
                                
                                Invoke("Logging5", 3);

                                shieldObj.SetActive(true);
                                GManager.instance.PlaySE(ShieldSE);
                                InvokeRepeating("Logging6", span, span);
                                Invoke("Logging7", 1);//1秒後にvoid Logging7()を実行する
                            }
                        }

                        else if (damageeee == 3 && !bossnikamera)
                        {
                            bossnikamera = true;
                            Debug.Log("3回　踏まれた" + damageeee);
                            cameraDooon = true;
                            Debug.Log("ボスにカメラどーん！" + cameraDooon);
                            Invoke("Logging13", 0);//0秒後にvoid Logging13()を実行する
                            nowState = BossState.ClearEnsyutu;
                        }
                    }
                }
                break;

            case BossState.ClearEnsyutu:
                //クリア時の処理を書く
                if (!isDamageee && !isMoudame)
                {
                    isMoudame = true;
                    isDamageee = true;
                    Invoke("Logging12", 3.1f);
                }
                break;
        }
        
    }

    public void Attack()
    {
        isAttack = false;
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.transform.localPosition = new Vector3(-6.0f, 2.0f, 0.0f); // 座標を変更
        g.SetActive(true);

        g.transform.parent = null;//親子関係を解除
        g.transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Y軸に180°回転したボムがいたら0に戻す
        g.transform.eulerAngles = new Vector3(0f, 0f, 0f); // 同上

        Attt = true;
        if (Attt)
        {
            Attt = false;
            StartCoroutine(PlayerWin());
            //Debug.Log("Attt" + Attt);
        }
    }

    IEnumerator PlayerWin()
    {
        //3秒待機
        yield return new WaitForSeconds(3f);
        
        GameObject attackOld = GameObject.Find("Bomb(Clone)");
        if (attackOld)
        {
            attackOld.GetComponent<mob_AI>().enabled = false;
            //attackOld.name = "Bomb2"; // クローンしたオブジェクトの名前を変更
            Invoke("Logging2", 10);//30秒後にvoid Logging()を実行する
            Bttt = true;

            if (Cttt)
            {
                attackOld.name = "Bomb2"; // クローンしたオブジェクトの名前を変更
                Cttt = false;
                Fttt = true;
            }
            else if (Bttt)
            {
                attackOld.name = "Bomb3"; // クローンしたオブジェクトの名前を変更
                Ettt = true;
                Bttt = false;
                Cttt = true;
            }
        }
    }

    void Logging2()
    {
        Invoke("Logging", 30);//30秒後にvoid Logging()を実行する
    }
        void Logging()
    {
        if (Fttt)
        {
            GameObject Bomb22 = GameObject.Find("Bomb2");
            if (Bomb22)
            {
                Bomb22.GetComponent<Enemy_Bomb>().isJibaku = true;
                CancelInvoke("Logging2");
            }
            //Destroy(Bomb22);
        }
        if (Ettt)
        {
            GameObject Bomb33 = GameObject.Find("Bomb3");
            if (Bomb33)
            {
                Bomb33.GetComponent<Enemy_Bomb>().isJibaku = true;
            }
            //Destroy(Bomb33);
        }
    }

    void Logging3()
    {
        if (isDamageee && anim != null)
        {
            isDamageee = false;
            Debug.Log("ダメージアニメーション完了");
        }
    }

    void Logging4()
    {
        if (isBeam && anim != null)
        {
            isBeam = false;
            isBeamEnd = true;
            Debug.Log("ビームアニメーション完了");
        }
    }

    void Logging5()
    {
        if (isLight && anim != null)
        {
            isLight = false;
            nikaifumareta = true;
            Debug.Log("ライトアニメーション完了");
        }
    }

    void Logging6()
    {
        scaleXYZ += 0.1f;
        shieldObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
        //Debug.Log("scaleXYZ" + scaleXYZ);

        if (scaleXYZ >= 4.0f)
        {
            scaleXYZ = 4.0f;
            shieldObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            //Debug.Log("指定した大きさ以上にならないようにする" + scaleXYZ);
        }
    }

    void Logging7()
    {
        //Invokeで実行しているLogging6関数を停止する
        CancelInvoke("Logging6");
        scaleXYZ = 2.0f;
        shieldObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
        shieldObj.SetActive(false);
        //Debug.Log("Logging6" + shieldObj);
    }

    public void Attack2()
    {
        beamObj.SetActive(true);
        GManager.instance.PlaySE(BeamSE);
        //beamObj.transform.parent = null;//親子関係を解除不可
        InvokeRepeating("Logging8", span2, span2);
        Invoke("Logging9", 3);//3秒後にvoid Logging9()を実行する
    }

    void Logging8()
    {
        // transformを取得
        Transform myTransform = beamObj.transform;
        // 座標を取得
        Vector3 pos = myTransform.position;

        if (isMuki180)
        {
            pos.x += 0.1f;    // x座標へ0.1加算
            myTransform.position = pos;  // 座標を設定
        }
        else
        pos.x += -0.1f;    // x座標へ-0.1加算
        myTransform.position = pos;  // 座標を設定

        if (!isBeammm)
        {
            scaleX += 0.1f;
            beamObj.transform.localScale = new Vector3(scaleX, 2.0f, 2.0f);
            //Debug.Log("beamObj①" + scaleX);
        }
        if (scaleX >= 20.0f)
        {
            isBeammm = true; 
        }
        if (isBeammm)
        {
            scaleX += -0.1f;
            beamObj.transform.localScale = new Vector3(scaleX, 2.0f, 2.0f);
            //Debug.Log("beamObj②" + scaleX);
        }
    }

    void Logging9()
    {
        //Invokeで実行しているLogging8関数を停止する
        CancelInvoke("Logging8");
        beamObj.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        beamObj.transform.localPosition = new Vector3(-5.0f, 4.2f, 0.0f);
        beamObj.SetActive(false);
        isFumareta = false;
        //Debug.Log("Logging8" + beamObj);
    }

    public void Attack3()
    {
        lightObj.SetActive(true);
        //lightObj.transform.parent = null;//親子関係を解除不可
        lightObj_ue.SetActive(true);
        //lightObj_ue.transform.parent = null;//親子関係を解除不可
        lightObj_sita.SetActive(true);
        //lightObj_sita.transform.parent = null;//親子関係を解除不可
        GManager.instance.PlaySE(LightningSE);
        InvokeRepeating("Logging10", span2, span2);
        Invoke("Logging11", 3);//3秒後にvoid Logging9()を実行する
    }

    void Logging10()
    {
        //コライダーのサイズをオブジェクトに合わせる
        Vector3 objectSize = lightObj.GetComponent<SpriteRenderer>().bounds.size;
        BoxCollider2D collider = lightObj.GetComponent<BoxCollider2D>();
        collider.size = objectSize;
        Vector3 objectSize1 = lightObj_ue.GetComponent<SpriteRenderer>().bounds.size;
        BoxCollider2D collider1 = lightObj_ue.GetComponent<BoxCollider2D>();
        collider1.size = objectSize1;
        Vector3 objectSize2 = lightObj_sita.GetComponent<SpriteRenderer>().bounds.size;
        BoxCollider2D collider2 = lightObj_sita.GetComponent<BoxCollider2D>();
        collider2.size = objectSize2;

        SpriteRenderer SPwidth = lightObj.GetComponent<SpriteRenderer>();
        SpriteRenderer SPwidth_ue = lightObj_ue.GetComponent<SpriteRenderer>();
        SpriteRenderer SPwidth_sita = lightObj_sita.GetComponent<SpriteRenderer>();

        float width = lightObj.GetComponent<SpriteRenderer>().bounds.size.x;
        float width1 = lightObj_ue.GetComponent<SpriteRenderer>().bounds.size.x;
        float width2 = lightObj_sita.GetComponent<SpriteRenderer>().bounds.size.x;
        

        isBeammm = true;

        if (isBeammm && !isLightooo)
        {
            //Debug.Log("isBeammmにはいったよ" + isBeammm);
            width += 0.1f;    
            SPwidth.size = new Vector2(width, 2.56f);
            
            SPwidth.transform.localPosition = new Vector3(-width, 5.0f, 0.0f);

            width1 += 0.3f;    
            SPwidth_ue.size = new Vector2(width1, 2.56f);
            width2 += 0.3f;
            SPwidth_sita.size = new Vector2(width2, 2.56f);
        }
    }

    void Logging11()
    {
        //Invokeで実行しているLogging10関数を停止する
        CancelInvoke("Logging10");

        SpriteRenderer SPwidth = lightObj.GetComponent<SpriteRenderer>();
        SpriteRenderer SPwidth_ue = lightObj_ue.GetComponent<SpriteRenderer>();
        SpriteRenderer SPwidth_sita = lightObj_sita.GetComponent<SpriteRenderer>();

        // 設定
        SPwidth.size = new Vector2(10.24f, 2.56f);
        SPwidth_ue.size = new Vector2(10.24f, 2.56f);
        SPwidth_sita.size = new Vector2(10.24f, 2.56f);
        
        lightObj.transform.localPosition = new Vector3(-9.0f, 5.0f, 0.0f);
        lightObj_ue.transform.localPosition = new Vector3(-8.0f, 8.0f, 0.0f);
        lightObj_sita.transform.localPosition = new Vector3(-8.0f, 1.0f, 0.0f);
        lightObj.SetActive(false);
        lightObj_ue.SetActive(false);
        lightObj_sita.SetActive(false);
        isFumareta = false;
        //Debug.Log("Logging10” + lightObj);
    }

    void Logging12()
    {
        if (isMoudame)
        {
            isDamageee = false;
            isDead = true;
            anim.Play("death");
            GManager.instance.PlaySE(DeathSE);
            //Debug.Log("DeathSE" + DeathSE);
            GManager.instance.score += myScore;
            Destroy(gameObject, 8.0f);
            Destroy(moveFloor, 8.0f);
            WarpDoor.SetActive(true);
        }
    }

    void Logging13()
    {
        oc.playerStepOn = false;
        isDamage = false;
        isFumareta = true;
        anim.Play("damage");
        GManager.instance.PlaySE(DamageSE);
        moveFloor.GetComponent<MoveObject>().enabled = false;
    }

    void Logging14()
    {
        //moveFloor.GetComponent<MoveObject>().enabled = true;
        
    }
}
