using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUP : MonoBehaviour
{

    [Header("加算するスピード")] public float mySpeed;
    [Header("加算するスピードの上限")] public float endSpeed;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;

    private Text speedText = null;
    private float oldSpeed = 3;
    public Text highSpeedText; //ハイスピードを表示するText
    private float highSpeed; //ハイスピード用変数
    private string key = "HIGH SPEED"; //ハイスピードの保存先キー
    private bool hs = true;


    // Start is called before the first frame update
    void Start()
    {
        highSpeed = PlayerPrefs.GetFloat(key, 3.0001f);
        //保存しておいたハイスピードをキーで呼び出し取得し保存されていなければ5になる

        highSpeedText.text = highSpeed.ToString();
        speedText = GetComponent<Text>();

        if (Player.instance != null)
        {
            Player.instance.speed = highSpeed;
            Player.instance.jumpSpeed = highSpeed + 3;//ジャンプスピードがスピード+3になるようにした
        }
        else
        {
            Debug.Log("プレイヤー置き忘れてるよ！");
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        {
            //プレイヤーが判定内に入ったら
            if (playerCheck.isOn & hs)
            {
                if (Player.instance != null)
                {
                    if (endSpeed > highSpeed)
                    {
                        Player.instance.speed += mySpeed;
                        oldSpeed = Player.instance.speed;
                    }
                    else
                    hs = false;
                }
                //ハイスピードより現在のスピードが高い時
                if (oldSpeed > highSpeed & hs)
                {

                    highSpeed = oldSpeed;
                    //ハイスピード更新

                    PlayerPrefs.SetFloat(key, highSpeed);
                    //ハイスピードを保存

                    highSpeedText.text = "SPEED UP" + highSpeed.ToString();
                    //ハイスピードを表示
                    hs = false;
                    //Destroy(this.gameObject);
                }
                
            }
        }
    }
}
