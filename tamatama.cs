using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamatama : MonoBehaviour
{
    //[Header("玉")] public GameObject Otama;
    //private Enemy_Zako1 tata;
    private string enemyTag = "Enemy";
    [Header("たまたま")] public bool yaruyo = false;


    #region//接触判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //tata = GameObject.Find("tama(Clone)").GetComponent<Enemy_Zako1>();
        //bool OOtama = (collision.collider.gameObject == tata);
        bool enemy = (collision.collider.tag == enemyTag);
        if (yaruyo && enemy)
        {
            Destroy(gameObject, 1f);
        }
    }
    #endregion
}