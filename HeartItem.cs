using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    [Header("加算するハート")] public int myHeart;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;
    [Header("アイテム取得時に鳴らすSE")] public AudioClip itemSE;

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.heartNum += myHeart;
                GManager.instance.PlaySE(itemSE);
                Destroy(this.gameObject);
            }
        }
    }
}