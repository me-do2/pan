﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCtrl : MonoBehaviour
{
    [Header("プレイヤーゲームオブジェクト")] public GameObject playerObj;
    [Header("コンティニュー位置")] public GameObject[] continuePoint;
    [Header("ゲームオーバー")] public GameObject gameOverObj;
    [Header("フェード")] public FadeImage fade;
    [Header("ゲームオーバー時に鳴らすSE")] public AudioClip gameOverSE;
    [Header("リトライ時に鳴らすSE")] public AudioClip retrySE;
    [Header("ステージクリアーSE")] public AudioClip stageClearSE;
    [Header("ステージクリア")] public GameObject stageClearObj;
    [Header("ステージクリア判定")] public PlayerTriggerCheck stageClearTrigger;

    private Player p;
    private int nextStageNum;
    private bool startFade = false;
    private bool doGameOver = false;
    private bool retryGame = false;
    private bool doSceneChange = false;
    private bool doClear = false;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj != null && continuePoint != null && continuePoint.Length > 0 && gameOverObj != null && fade != null && stageClearObj != null)
        {
            gameOverObj.SetActive(false);
            stageClearObj.SetActive(false);
            playerObj.transform.position = continuePoint[0].transform.position;
            p = playerObj.GetComponent<Player>();
            if (p == null)
            {
                Debug.Log("プレイヤーじゃない物がアタッチされているよ！");
            }
        }
        else
        {
            Debug.Log("設定が足りてないよ！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時の処理
        if (GManager.instance.isGameOver && !doGameOver)
        {
            gameOverObj.SetActive(true);
            GManager.instance.PlaySE(gameOverSE);
            Time.timeScale = 0f;
            doGameOver = true;
        }
        //プレイヤーがやられた時の処理
        else if (p != null && p.IsContinueWaiting() && !doGameOver)
        {
            if (continuePoint.Length > GManager.instance.continueNum)
            {
                //Debug.Log("continuePoint.Length" + continuePoint.Length);
                //Debug.Log("GManager.instance.continueNum" + GManager.instance.continueNum);
                playerObj.transform.position = continuePoint[GManager.instance.continueNum].transform.position;

                p.ContinuePlayer();
            }
            else
            {
                Debug.Log("コンティニューポイントの設定が足りてないよ！");
            }
        }
        else if (stageClearTrigger != null && stageClearTrigger.isOn && !doGameOver && !doClear)
        {
            StageClear();
            doClear = true;
        }

        //ステージを切り替える
        if (fade != null && startFade && !doSceneChange)
        {
            if (fade.IsFadeOutComplete())
            {
                //ゲームリトライ
                if (retryGame)
                {
                    GManager.instance.RetryGame();
                }
                //次のステージ
                else
                {
                    //GManager.instance.stageNum = nextStageNum;
                    GManager.instance.score = 0;
                    GManager.instance.continueNum = 0;
                    GManager.instance.stageclear = 0;
                }
                GManager.instance.isStageClear = false;
                SceneManager.LoadScene("ButtonScene");
                doSceneChange = true;
                Time.timeScale = 1.0f;
            }
        }
    }

    

    /// <summary>
    /// 最初から始める
    /// </summary>
    public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        GManager.instance.RetryGame();
        SceneManager.LoadScene("ButtonScene");
        retryGame = true;
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// ステージを切り替えます。
    /// </summary>
    /// <param name="num">ステージ番号</param>
    public void ChangeScene(int num)
    {
        if (fade != null)
        {
            nextStageNum = num;
     
            //DelayMethodを3.0秒後に呼び出す
            Invoke("DelayMethod", 3.0f);
        }
    }

    public void DelayMethod()
    {
        Debug.Log("Delay call");
        fade.StartFadeOut();
        startFade = true;
    }

    /// <summary>
    /// ステージをクリアした
    /// </summary>
    public void StageClear()
    {
        GManager.instance.isStageClear = true;
        stageClearObj.SetActive(true);
        GManager.instance.PlaySE(stageClearSE);
        //ステージクリア用
        GManager.instance.stageclear += 1;
    }
}