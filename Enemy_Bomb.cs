using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bomb : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("接地判定")] public GroundCheck ground;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;
    [Header("爆破SE")] public AudioClip bakuhaSE;
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("右向き")] public bool migimuki;
    [Header("上接触判定(敵)")] public EnemyGA ueni;
    #endregion

    #region//プライベート変数
    [HideInInspector] public Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    [HideInInspector] public Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private SpriteRenderer sprr = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    [HideInInspector] public bool isGround = false;
    [HideInInspector] public bool isEnemy = false;
    [HideInInspector] public bool isOn = false;
    [HideInInspector] public bool isJibaku = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();
        sprr = GetComponent<SpriteRenderer>();

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
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisibleAct)
            {
                //接地判定を得る
                isGround = ground.IsGround();
                isEnemy = ground.IsEnemy();
                isOn = checkCollision.IsOn();
                //アニメーションを適用
                SetAnimation();
                //重力を適用
                rb.velocity = new Vector2(0, -gravity);

                if (migimuki)
                {
                    if (isOn)
                    {
                        rightTleftF = !rightTleftF;
                    }
                    int xVector2 = 1;
                    if (rightTleftF)
                    {
                        xVector2 = -1;
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    //地面にいる時またはエネミーをふんずけている時
                    if (isGround || isEnemy)
                    {
                        rb.velocity = new Vector2(xVector2 * speed, -gravity);
                    }
                    if (ueni.iruyo)
                    {
                        //質量を2にする
                        rb.mass = 2;
                    }
                    else
                        //質量を0.0001にする
                        rb.mass = 0.0001f;
                }
                else
                {
                    if (isOn)
                    {
                        rightTleftF = !rightTleftF;
                    }
                    int xVector = -1;
                    if (rightTleftF)
                    {
                        xVector = 1;
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    //地面にいる時またはエネミーをふんずけている時
                    if (isGround || isEnemy)
                    {
                        rb.velocity = new Vector2(xVector * speed, -gravity);
                    }
                    if (ueni.iruyo)
                    {
                        //質量を2にする
                        rb.mass = 2;
                    }
                    else
                        //質量を0.0001にする
                        rb.mass = 0.0001f;
                }
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if (!isDead)
            {

                anim.Play("Bomb_add");
                //rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                if (GManager.instance != null)
                {
                    GManager.instance.PlaySE(deadSE);
                    GManager.instance.score += myScore;
                }
                Destroy(gameObject, 1.5f);
            }
            else
            {
                //transform.Rotate(new Vector3(0, 0, 5));
                anim.SetTrigger("attack");
            }
        }
        if (isJibaku)
        {
            anim.Play("Bomb_add");
            isJibaku = false;
            isDead = true;
            col.enabled = false;
            if (GManager.instance != null)
            {
                GManager.instance.PlaySE(deadSE);
                //GManager.instance.score += myScore;
            }
            Destroy(gameObject, 1.5f);
            anim.SetTrigger("attack");
        }
    }
    /// <summary>
    /// アニメーションを設定する
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("ground", isGround);
    }

    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.SetActive(true);

        if (GManager.instance != null)
        {
            GManager.instance.PlaySE(bakuhaSE);
            sprr.enabled = false;
        }
    }
}