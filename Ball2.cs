using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    private Rigidbody2D rb = null;

    [Header("最大移動距離")] public float maxDistance = 100.0f;
    private Vector3 defaultPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        float d = Vector3.Distance(transform.position, defaultPos);

        //最大移動距離を超えている
        if (d > maxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            int xVector = 1;
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }   
    }
}
