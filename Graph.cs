using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Graph : MonoBehaviour
{
    private float highSpeed; //ハイスピード用変数
    public Text highSpeedText; //ハイスピードを表示するText
    private string key = "HIGH SPEED"; //ハイスピードの保存先キー
    public Text st; //スピードのレベルを表示するText

    // Start is called before the first frame update
    void Start()
    {
        highSpeed = PlayerPrefs.GetFloat(key, 3.0001f);
        //保存しておいたハイスピードをキーで呼び出し取得し保存されていなければ5になる
        //Debug.Log("highSpeed：" + highSpeed);
        highSpeedText.text = highSpeed.ToString();
        //Debug.Log("データでの速さ" + highSpeedText.text);

        string fff = highSpeedText.text.Substring(0, 1);   //5のみを抜き出す.文字列の一部を抜き出す方法「Substring」
        //Debug.Log("少数fff：" + fff);
        //整数の場合
        int ggg = int.Parse(fff);//文字列を数字へ変換する方法「Parse」
        //Debug.Log("整数ggg：" + ggg);
        float sss = highSpeed - ggg;
        //データでの速さ(正確なデータの少数)からデータでのスピードの最初の数字の整数(5)を引く
        //Debug.Log("少数sss：" + sss);
        float num = float.Parse(highSpeedText.text);
        //データでの速さをnumにする
        //Debug.Log("少数num：" + num);

        float bbb = sss + 0.0001f;                  //0.2850032
        string ccc = bbb.ToString();        //ストリング(文字列)に変える”0.2850032”
        //Debug.Log("文字列ccc：" + ccc);
        string ddd = ccc.Substring(3, 2);   //85のみを抜き出す
        //Debug.Log("文字列ddd：" + ddd);
        try
        {
            //整数の場合
            int eee = int.Parse(ddd);
            //Debug.Log("整数です：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }
        catch
        {
            //小数の場合
            float eee = float.Parse(ddd);
            //Debug.Log("小数です：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }

        float sT = num * 10;//データでの速さ5.050001 * 10 = 30.50001
        //Debug.Log("スピードレベル" + sT);

        int ts;//int型の変数tsを宣言
        ts = (int)sT;//sTをint型に変換し変数tsに代入 小数点以下を消す　30となる
        //Debug.Log("2スピードレベル" + ts);

        int tt = ts + 20;
        //Debug.Log("3スピードレベル" + tt);

        string sst = tt.ToString();//tsをstring型変換し変数sstに代入
        //Debug.Log("4スピードレベル" + sst);
        st.text = sst;//sstはstring型なのでtextに代入できる
    }
}