using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    /// <summary>
    /// 判定内に敵か壁かヒットエリアがある
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string groundTag = "Ground";
    private string enemyTag = "Enemy";
    private string hitAreaTag = "HitArea";
    //private bool isOn = false;
    private bool isEnemyEnter, isEnemyStay, isEnemyExit;

    //接地判定を返すメソッド
    public bool IsOn()
    {
        if (isEnemyEnter || isEnemyStay)
        {
            isOn = true;
        }
        else if (isEnemyExit)
        {
            isOn = false;
        }
        isEnemyEnter = false;
        isEnemyStay = false;
        isEnemyExit = false;
        return isOn;
    }

    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag || collision.tag == hitAreaTag)
        {
            isEnemyEnter = true;
            isOn = true;
            //Debug.Log("エンター" + isEnemyEnter);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag || collision.tag == hitAreaTag)
        {
            isEnemyStay = true;
            isOn = true;
            //Debug.Log("ステイ" + isEnemyStay);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag || collision.tag == hitAreaTag)
        {
            isEnemyExit = true;
            isOn = false;
            //Debug.Log("イクジット" + isEnemyExit);
        }
    }
    #endregion
}
