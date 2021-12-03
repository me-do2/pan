using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigiHidari : MonoBehaviour
{
    public float StartPos = 0.1f;
    private Vector3 targetpos;
    //[Header("スワイプスクリプト")] public Swipe swww;

    void Start()
    {
        targetpos = transform.position;
    }

    void Update()
    {
        
        transform.position = new Vector3(Mathf.Sin(Time.time) * StartPos + targetpos.x, targetpos.y, targetpos.z);
    }
}