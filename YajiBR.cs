﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YajiBR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        //Debug.Log("右ボタン押したよ！");
        GameObject PL2 = GameObject.Find("Player2");
        //Debug.Log("PL2" + PL2);
        PL2.GetComponent<Swipe>().direction = "right";
        //Debug.Log("PL3" + PL2);
        PL2.GetComponent<Swipe>().isMove = true;
        //Debug.Log("isMove = true");
    }
}
