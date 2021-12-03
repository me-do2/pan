using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveObject3 : MonoBehaviour
{
    [Header("移動経路")] public GameObject[] movePoint;
    [Header("速さ")] public float speed = 1.0f;

    private Rigidbody2D rb;
    private int nowPoint = 0;
    private bool returnPoint = false;
    public Vector2 oldPos = Vector2.zero;
    private Vector2 myVelocity = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movePoint != null && movePoint.Length > 0 && rb != null)
        {
            rb.position = movePoint[0].transform.position;
            oldPos = rb.position;
        }
    }

    public Vector2 GetVelocity()
    {
        return myVelocity;
    }

    private void FixedUpdate()
    {
        if (movePoint != null && movePoint.Length > 1 && rb != null)
        {
            //通常進行
            if (!returnPoint)
            {
                int nextPoint = nowPoint + 1;

                //目標ポイントとの誤差がわずかになるまで移動
                if (Vector2.Distance(transform.position, movePoint[nextPoint].transform.position) > 0.1f)
                {
                    //現在地から次のポイントへのベクトルを作成
                    Vector2 toVector = Vector2.MoveTowards(transform.position, movePoint[nextPoint].transform.position, speed * Time.deltaTime);
                    //Debug.Log("toVector" + toVector);

                    

                    //次のポイントへ移動
                    rb.MovePosition(toVector);
                }
                //次のポイントを１つ進める
                else
                {
                    rb.MovePosition(movePoint[nextPoint].transform.position);
                    ++nowPoint;
                    //現在地が配列の最後だった場合
                    if (nowPoint + 1 >= movePoint.Length)
                    {
                        returnPoint = true;
                    }
                }
            }
            //停止する
            else
            {
                //Debug.Log("vcam2が最後まで到達");
            }
            myVelocity = (rb.position - oldPos) / Time.deltaTime;
            //Debug.Log("myVelocity" + myVelocity);
            oldPos = rb.position;
            //Debug.Log("oldPos" + oldPos);
        }
    }
}