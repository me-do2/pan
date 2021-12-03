using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RemainTimer : MonoBehaviour
{
    [SerializeField] float gameTime = 20.0f;        // ゲーム制限時間 [s]
    Text uiText;                                    // UIText コンポーネント
    float currentTime;                              // 残り時間タイマー

    public int minutes;
    public int seconds;
    public static RemainTimer instance = null;		//①空箱
    private void Awake()						    //②Startによく似たメソッド
    {
        if (instance == null)						//③もしスタティックな変数が空箱だった場合
        {
            instance = this;						//④このインスタンスのアドレスを入れる　空箱の中に中身を入れることができた
        }
    }

    void Start()
    {
        // Textコンポーネント取得
        uiText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime;
    }

    void Update()
    {
        // 残り時間を計算する
        currentTime -= Time.deltaTime;

        // ゼロ秒以下にならないようにする
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        minutes = Mathf.FloorToInt(currentTime / 60F);
        seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        uiText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (currentTime <= 0f)
        {
            GManager.instance.SubHeartNum();
        }
    }
}