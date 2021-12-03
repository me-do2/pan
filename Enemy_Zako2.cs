using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako2 : MonoBehaviour
{
    [Header("加算スコア")] public int myScore;
    [Header("攻撃オブジェクト")] public GameObject attackObj;
    [Header("攻撃間隔")] public float interval;
    [Header("重力")] public float gravity;
    [Header("接触判定")] public EnemyCollisionCheck checkCollision;
    [Header("やられた時に鳴らすSE")] public AudioClip deadSE;

    private Rigidbody2D rb;
    private Animator anim;
    private float timer;
    private ObjectCollision oc;					//②橋渡をするスクリプト
    private BoxCollider2D col;						//③２Dコライダーの変数
    private bool isDead = false;						//④


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();			//⑥
        col = GetComponent<BoxCollider2D>();			//⑦
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

    // Update is called once per frame
    void Update()
    {
        if (!oc.playerStepOn)                           //⑧橋渡しするスクリプトからプレイヤーに踏まれたかどうか
        {

            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

            //通常の状態
            if (currentState.IsName("idle"))
            {
                if (timer > interval)
                {
                    anim.SetTrigger("attack");
                    timer = 0.0f;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        else											//⑨踏まれた時の処理
        {
            if (!isDead)									//フラグを一回しか通らないように
            {
                anim.Play("idle");							//敵は踏まれた時　下に落ちていく形にして当たり判定を消す
                rb.velocity = new Vector2(0, -gravity);
                isDead = true;
                col.enabled = false;
                GManager.instance.PlaySE(deadSE);
                GManager.instance.score += myScore;
                Destroy(gameObject, 1f);
            }
        }
    }

    public void Attack()
    {
        GameObject g = Instantiate(attackObj);
        g.transform.SetParent(transform);
        g.transform.position = attackObj.transform.position;
        g.SetActive(true);
    }
}
