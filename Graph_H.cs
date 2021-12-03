using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Graph_H : MonoBehaviour
{
    private float highHeart; //ハイハート用変数
    public Text highHeartText; //ハイハートを表示するText
    private string key = "HIGH HEAT"; //ハイハートの保存先キー
    public Text hp; //ハートのレベルを表示するText

    // Start is called before the first frame update
    void Start()
    {
        highHeart = PlayerPrefs.GetFloat(key, 3.0001f);
        //Debug.Log("highHeart：" + highHeart);
        //保存しておいたハイハートをキーで呼び出し取得し保存されていなければ3になる
        highHeartText.text = highHeart.ToString();//数字を文字列に変換する方法「ToString」
        //Debug.Log("データでのハート" + highHeartText.text);

        string fff = highHeartText.text.Substring(0, 1);   //3のみを抜き出す.文字列の一部を抜き出す方法「Substring」
        //Debug.Log("ハート整数fff：" + fff);

        //整数の場合
        int ggg = int.Parse(fff);//文字列を数字へ変換する方法「Parse」
        //Debug.Log("ハート整数ggg：" + ggg);

        float sss = highHeart - ggg;
        //Debug.Log("sss：" + sss);
        //データでのハート(正確なデータの少数)からデータでのハートの最初の数字の整数(3)を引く

        float bbb = sss + 0.0001f;  //0.002  0.005999565+0.0001=0.006099565 59ではなく60にしたい
        //Debug.Log("ハート整数bbb：" + bbb);
        

        string ccc = bbb.ToString();        //ストリング(文字列)に変える”0.002”
        //Debug.Log("ハート整数ccc：" + ccc);
        string ddd = ccc.Substring(3, 2);   //02のみを抜き出す
        //Debug.Log("ハート整数ddd：" + ddd);
        try
        {
            //整数の場合
            int eee = int.Parse(ddd);
            //Debug.Log("ハート整数eee：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }
        catch
        {
            //小数の場合
            float eee = float.Parse(ddd);
            //Debug.Log("ハート小数eee：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }

        float sT = highHeart * 10;//データでのハート3.002 * 10 = 30.02
        //Debug.Log("ハートレベル" + sT);

        int ts;//int型の変数tsを宣言
        ts = (int)sT;//sTをint型に変換し変数tsに代入 小数点以下を消す　50.02となる
        int tt = ts + 20;
        //Debug.Log("2ハートレベル" + tt);

        string sst = tt.ToString();//tsをstring型変換し変数sstに代入
        //Debug.Log("3ハートレベル" + sst);
        hp.text = sst;//sstはstring型なのでtextに代入できる
    }
}