using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScoreItem : MonoBehaviour
{
    [Header("加算するコインスコア")] public int CoinMyScore;
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
                GManager.instance.coinscore += CoinMyScore;
                GManager.instance.PlaySE(itemSE);
                Destroy(this.gameObject);
            }
        }
    }
}