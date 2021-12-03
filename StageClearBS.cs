using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;//Convertを使う場合は忘れずに書く

public class StageClearBS : MonoBehaviour
{
    public Text StageClearText; //ステージクリアを表示するText
    private int StageClear; //ステージクリア用変数
    private string key = "STAGE CLEAR"; //ステージクリアの保存先キー
    private string key2 = "COIN HIGH SCORE"; //ハイスコアの保存先キー
    [Header("現在のステージ")] public int stage;
    public GameObject StageclearObj;
    public GameObject CompleteObj;

    private int CoinHighScore; //ハイスコア用変数
    public Text CoinHighScoreText; //ハイスコアを表示するText
    private bool compYo = false;

    void Start()
    {
        StageClear = PlayerPrefs.GetInt(key + stage, 0);
        //Debug.Log("StageClear" + StageClear);
        //保存しておいたステージクリアをキーで呼び出し取得し保存されていなければ0になる
        StageClearText.text = StageClear.ToString();
        //ステージクリアテキストを表示

        CoinHighScore = PlayerPrefs.GetInt(key2 + stage, 0);
        //Debug.Log("CoinHighScore" + CoinHighScore);
        CoinHighScoreText.text = CoinHighScore.ToString();
        //ハイスコアを表示
    }

    void Update()
    {
        //サッカーボールコイン数
        string text123 = CoinHighScoreText.text;
        //文字から数字へ型変換
        int num1 = int.Parse(text123);
       
        if (num1 == 3)
        {
            StageclearObj.SetActive(false);
            CompleteObj.SetActive(true);
            compYo = true;
        }
        
        //ゲームクリア
        string SCText = StageClearText.text;
        //文字から数字へ型変換
        int sct = int.Parse(SCText);

        if (sct == 1 && !compYo)
        {
            StageclearObj.SetActive(true);
            
        }
    }
}
