using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text scoreText = null;
    //private int oldScore = 0;
    public Text highScoreText; //ハイスコアを表示するText
    private int highScore; //ハイスコア用変数
    private string key = "HIGH SCORE"; //ハイスコアの保存先キー
    [Header("現在のステージ")] public int stage;


    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(key + stage, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "" + highScore.ToString();
        //ハイスコアを表示
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
