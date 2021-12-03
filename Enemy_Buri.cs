using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Buri : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("加算スコア")] public int myScore;
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private ObjectCollision oc = null;
    //private BoxCollider2D col = null;
    private CapsuleCollider2D col = null;
    private bool isDead = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oc = GetComponent<ObjectCollision>();
        //col = GetComponent<BoxCollider2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        if (oc.playerStepOn)
        {
            if (!isDead)
            {
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
        else
        {
            
        }
    }
}