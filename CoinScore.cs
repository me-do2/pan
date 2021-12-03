using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    private Text CoinScoreText = null;
    private int CoinOldScore = 0;
    public Text CoinHighScoreText; //ハイスコアを表示するText
    private int CoinHighScore; //ハイスコア用変数
    private string key = "COIN HIGH SCORE"; //ハイスコアの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        CoinHighScore = PlayerPrefs.GetInt(key + GManager.instance.stageNum, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        CoinHighScoreText.text = CoinHighScore.ToString() + "/3";
        //ハイスコアを表示

        CoinScoreText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            CoinScoreText.text = "× " + GManager.instance.coinscore;
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
        if (CoinOldScore > CoinHighScore)
        {

            CoinHighScore = CoinOldScore;
            //ハイスコア更新

            PlayerPrefs.SetInt(key + GManager.instance.stageNum, CoinHighScore);
            //ハイスコアを保存

            CoinHighScoreText.text = CoinHighScore.ToString() + "/3";
            //ハイスコアを表示
        }

        if (CoinOldScore != GManager.instance.coinscore)
        {
            CoinScoreText.text = "× " + GManager.instance.coinscore;
            CoinOldScore = GManager.instance.coinscore;
        }
    }
}