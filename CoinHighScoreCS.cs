using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;//Convertを使う場合は忘れずに書く

public class CoinHighScoreCS : MonoBehaviour
{
    //private Text CoinScoreText = null;
    //private int CoinOldScore = 0;
    public Text CoinHighScoreText; //ハイスコアを表示するText
    private int CoinHighScore; //ハイスコア用変数
    private string key = "COIN HIGH SCORE"; //ハイスコアの保存先キー
    [Header("現在のステージ")] public int stage;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    //private int nmu2 = 2;
    //private string mmm = "1";
    //private string yyy = "2";
    //private string sss = "3";


    // Start is called before the first frame update
    void Start()
    {
        CoinHighScore = PlayerPrefs.GetInt(key + stage, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        CoinHighScoreText.text = CoinHighScore.ToString();
        //ハイスコアを表示

        //数字から文字へ型変換
        //string text1 = (num1).ToString();
        //string text2 = Convert.ToString(num2);
        //Debug.Log("text1" + text1);
        //Debug.Log("text2" + text2);
        //CoinHighScoreText.text = num1 + text1 + "\r\n" + num2 + text2;//表示テスト
        //0より現在スコアが高い時
    }

    void Update()
    {
        string text123 = CoinHighScoreText.text;
        //文字から数字へ型変換
        int num1 = int.Parse(text123);
        //int num2 = Convert.ToInt32(text123);
        //Debug.Log(num1);
        //Debug.Log("num2" + num2);

        if (num1 == 1)
        {
            coin1.SetActive(true);
            coin2.SetActive(false);
            coin3.SetActive(false);
        }
        if (num1 == 2)
        {
            coin1.SetActive(true);
            coin2.SetActive(true);
            coin3.SetActive(false);
        }
        if (num1 == 3)
        {
            coin1.SetActive(true);
            coin2.SetActive(true);
            coin3.SetActive(true);
        }
        if (num1 == 0)
        {
            coin1.SetActive(false);
            coin2.SetActive(false);
            coin3.SetActive(false);
        }
    }
}