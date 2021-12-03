using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUP_ST : MonoBehaviour
{

    [Header("加算するスピード")] public float mySpeed;
    [Header("加算するスピードの上限")] public float endSpeed;
    

    //private Text speedText = null;
    //private float oldSpeed = 3;
    public Text highSpeedText; //ハイスピードを表示するText
    private float highSpeed; //ハイスピード用変数
    private string key = "HIGH SPEED"; //ハイスピードの保存先キー
    


    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey(key);//keyのデータを削除したい時用
        highSpeed = PlayerPrefs.GetFloat(key, 3.0001f);
        //保存しておいたハイスピードをキーで呼び出し取得し保存されていなければ3.0001になる

        highSpeedText.text = highSpeed.ToString();
        //speedText = GetComponent<Text>();

        if (Player.instance != null)
        {
            Player.instance.speed = highSpeed;
        }
        else
        {
            Debug.Log("プレイヤー置き忘れてるよ！");
            Destroy(this);
        }
    }
}
