using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText = null;
    private int oldScore = 0;
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey(key + GManager.instance.stageNum);//keyのデータを削除したい時用
        highScore = PlayerPrefs.GetInt(key + GManager.instance.stageNum, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "" + highScore.ToString();
        //ハイスコアを表示

        scoreText = GetComponent<Text>();
        if(GManager.instance != null)
        {
            scoreText.text = "Score " + GManager.instance.score;
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
        if (oldScore > highScore)
        {

            highScore = oldScore;
            //ハイスコア更新

            PlayerPrefs.SetInt(key + GManager.instance.stageNum, highScore);
            //ハイスコアを保存

            highScoreText.text = "" + highScore.ToString();
            //ハイスコアを表示
        }

        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "Score " + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }
}