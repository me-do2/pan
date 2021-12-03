using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
    /// <summary>
    /// 判定内にプレイヤーがいる
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string PlayerTag = "Player";

    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerTag)
        {
            isOn = false;
        }
    }
    #endregion
}
