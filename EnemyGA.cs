using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGA : MonoBehaviour
{
    /// <summary>
    /// 判定内（上）に敵だけど仲間がいる
    /// </summary>
    [HideInInspector] public bool iruyo = false;

    private string enemyTag = "Enemy";

    #region//接触判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            iruyo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == enemyTag)
        {
            iruyo = false;
        }
    }
    #endregion
}
