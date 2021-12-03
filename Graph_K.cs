using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Graph_K : MonoBehaviour
{
    private float highKick; //ハイキック用変数
    public Text highKickText; //ハイキックを表示するText
    private string key = "HIGH KICK"; //ハイキックの保存先キー
    public Text kp; //キックのレベルを表示するText

    // Start is called before the first frame update
    void Start()
    {
        highKick = PlayerPrefs.GetFloat(key, 2.0001f);
        //Debug.Log("highSpeed：" + highKick);
        //保存しておいたハイキックをキーで呼び出し取得し保存されていなければ1.001になる
        highKickText.text = highKick.ToString();//数字を文字列に変換する方法「ToString」
        //Debug.Log("データでの速さ" + highKickText.text);
        //Debug.Log("データでのキック" + highKickText.text);

        string fff = highKickText.text.Substring(0, 1);   //3のみを抜き出す.文字列の一部を抜き出す方法「Substring」
        //Debug.Log("キック整数fff：" + fff);

        //整数の場合
        int ggg = int.Parse(fff);//文字列を数字へ変換する方法「Parse」
        //Debug.Log("キック整数ggg：" + ggg);

        float sss = highKick - ggg;
        //Debug.Log("sss：" + sss);
        //データでのキック(正確なデータの少数)からデータでのキックの最初の数字の整数(3)を引く

        float bbb = sss + 0.0001f; //0.002
        //Debug.Log("キック整数bbb：" + bbb);
        string ccc = bbb.ToString();        //ストリング(文字列)に変える”0.002”
        //Debug.Log("キック整数ccc：" + ccc);
        string ddd = ccc.Substring(3, 2);   //02のみを抜き出す
        //Debug.Log("キック整数ddd：" + ddd);
        try
        {
            //整数の場合
            int eee = int.Parse(ddd);
            //Debug.Log("キック整数eee：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }
        catch
        {
            //小数の場合
            float eee = float.Parse(ddd);
            //Debug.Log("キック小数eee：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }

        float sT = highKick * 10;//データでのキック2.0002 * 10 = 20.02
        //Debug.Log("キックレベル" + sT);

        int ts;//int型の変数tsを宣言
        ts = (int)sT;//sTをint型に変換し変数tsに代入 小数点以下を消す　50.02となる
        int tt = ts + 30;
        //Debug.Log("2キックレベル" + tt);
        string sst = tt.ToString();//tsをstring型変換し変数sstに代入
        //Debug.Log("3キックレベル" + sst);
        kp.text = sst;//sstはstring型なのでtextに代入できる
    }
}