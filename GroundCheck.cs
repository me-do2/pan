using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundCheck : MonoBehaviour
{
    [Header("エフェクトがついた床を判定するか")] public bool checkPlatformGroud = true;
    [Header("エネミーを判定するか")] public bool checkGroudEnemy = false;

    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private string moveFloorTag = "MoveFloor";
    private string fallFloorTag = "FallFloor";
    private string enemyTag = "Enemy";
    private bool isGround = false;
    private bool isEnemy = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;
    private bool isEnemyEnter, isEnemyStay, isEnemyExit;

    //接地判定を返すメソッド
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }
    public bool IsEnemy()
    {
        if (isEnemyEnter || isEnemyStay)
        {
            isEnemy = true;
        }
        else if (isEnemyExit)
        {
            isEnemy = false;
        }
        isEnemyEnter = false;
        isEnemyStay = false;
        isEnemyExit = false;
        return isEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag))
        {
            isGroundEnter = true;
        }
        else if (checkGroudEnemy && collision.tag == enemyTag)
        {
            isEnemyEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag))
        {
            isGroundStay = true;
        }
        else if (checkGroudEnemy && collision.tag == enemyTag)
        {
            isEnemyStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
        }
        else if (checkPlatformGroud && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag))
        {
            isGroundExit = true;
        }
        else if (checkGroudEnemy && collision.tag == enemyTag)
        {
            isEnemyExit = true;
        }
    }
}