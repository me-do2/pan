using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama_LR : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("接触判定2")] public GroundCheck gCheck;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;
    [Header("ポリス")] public Enemy_LR Enemy_poli;
    [HideInInspector] public bool isGround = false;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;
    private bool rightTleftF = false;
    private bool isDead = false;
    private bool isTTTT = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisibleAct)
            {
                //接地判定を得る
                isGround = gCheck.IsGround();

                if (checkCollision.isOn || isGround)
                {
                    rightTleftF = !rightTleftF;
                }
                GameObject tamaOld = GameObject.Find("tama(Clone)");
                //Debug.Log("tamaOld:  " + tamaOld.activeSelf);//インスペクター確認
                isTTTT = (tamaOld.activeSelf);

                if (isTTTT)
                {
                    Invoke("Logging", 30);//30秒後にvoid Logging()を実行する
                }

                int xVector = 1;
                if (Enemy_poli.migimuki)
                {
                    if (rightTleftF)
                    {
                        xVector = -1;
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    rb.velocity = new Vector2(xVector * speed, -gravity);
                }
                else if (rightTleftF)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    xVector = -1;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
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
                anim.Play("dead");
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                if (GManager.instance != null)
                {
                    GManager.instance.PlaySE(deadSE);
                    GManager.instance.score += myScore;
                }
                Destroy(gameObject, 3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
        }
    }

    void Logging()
    {
        GameObject tamaOld = GameObject.Find("tama(Clone)");
        Destroy(tamaOld);
    }
}