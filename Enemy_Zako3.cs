using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako3 : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;
    [Header("上下する移動範囲")] public float MovingDistance = 2;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private CapsuleCollider2D col = null;
    private bool isDead = false;
    private float StartPos;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<CapsuleCollider2D>();
        StartPos = transform.position.y;
    }

    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisibleAct)
            {
                transform.position = new Vector3(transform.position.x, StartPos + Mathf.PingPong(Time.time * 2f, MovingDistance), transform.position.z);
            }
            else                                                //⑨画面に写っていない間、スリープ状態にする
            {
                rb.Sleep();
            }
        }
            else
            {
                if (!isDead)
                {

                    anim.Play("dead");
                    rb.velocity = new Vector2(0, -gravity);
                    isDead = true;
                    col.enabled = false;
                    if (GManager.instance != null)
                {
                    GManager.instance.PlaySE(deadSE);
                    GManager.instance.score += myScore;
                }
                    Destroy(gameObject, 0.45f);
                }
                else
                {
                transform.Rotate(new Vector3(0, 0, 5));
                }
            }
    }
}