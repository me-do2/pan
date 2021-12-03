using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageClearST : MonoBehaviour
{
    private Text StageClearText = null;
    private int SClearOldScore = 0;
    public Text SClearHighScoreText; //ステージクリアを表示するText
    private int SClearHighScore; //ステージクリア用変数
    private string key = "STAGE CLEAR"; //ステージクリアの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        SClearHighScore = PlayerPrefs.GetInt(key + GManager.instance.stageNum, 0);
        //保存しておいたステージクリアをキーで呼び出し取得し保存されていなければ0になる
        SClearHighScoreText.text = SClearHighScore.ToString() + "/1";
        //ハイスコアを表示

        StageClearText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            StageClearText.text = "× " + GManager.instance.stageclear;
        }
        else
        {
            Debug.Log("ゲームマネージャー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアより現在スコアが高い時
        if (SClearOldScore > SClearHighScore)
        {
            SClearHighScore = SClearOldScore;
            //ハイスコア更新
            PlayerPrefs.SetInt(key + GManager.instance.stageNum, SClearHighScore);
            //ハイスコアを保存
            SClearHighScoreText.text = SClearHighScore.ToString() + "/1";
            //ハイスコアを表示
        }

        if (SClearOldScore != GManager.instance.stageclear)
        {
            StageClearText.text = "× " + GManager.instance.stageclear;
            SClearOldScore = GManager.instance.stageclear;
        }
    }
}