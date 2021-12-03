using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Graph_J : MonoBehaviour
{
    private float highJump; //ハイジャンプ用変数
    public Text highJumpText; //ハイジャンプを表示するText
    private string key = "HIGH JUMP"; //ハイジャンプの保存先キー
    public Text jt; //ジャンプのレベルを表示するText

    // Start is called before the first frame update
    void Start()
    {
        highJump = PlayerPrefs.GetFloat(key, 4.0001f);
        //Debug.Log("highJump：" + highJump);
        //保存しておいたハイジャンプをキーで呼び出し取得し保存されていなければ3になる
        highJumpText.text = highJump.ToString();//数字を文字列に変換する方法「ToString」
        //Debug.Log("データでのジャンプ" + highJumpText.text);

        string fff = highJumpText.text.Substring(0, 1);   //3のみを抜き出す.文字列の一部を抜き出す方法「Substring」
        //Debug.Log("ジャンプ整数fff：" + fff);
        
        //整数の場合
        int ggg = int.Parse(fff);//文字列を数字へ変換する方法「Parse」
        //Debug.Log("ジャンプ整数ggg：" + ggg);
        
        float sss = highJump - ggg;
        //Debug.Log("sss：" + sss);
        //データでのジャンプ(正確なデータの少数)からデータでのジャンプの最初の数字の整数(3)を引く

        float bbb = sss + 0.0001f; //0.002
        //Debug.Log("ジャンプ整数bbb：" + bbb);
        string ccc = bbb.ToString();        //ストリング(文字列)に変える”0.002”
        //Debug.Log("ジャンプ整数ccc：" + ccc);
        string ddd = ccc.Substring(3, 2);   //02のみを抜き出す
        //Debug.Log("ジャンプ整数ddd：" + ddd);
        try
        {
            //整数の場合
            int eee = int.Parse(ddd);
            //Debug.Log("ジャンプ整数eee：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }
        catch
        {
            //小数の場合
            float eee = float.Parse(ddd);
            //Debug.Log("ジャンプ小数eee：" + eee);

            RectTransform transform = GetComponent<RectTransform>();
            transform.sizeDelta = new Vector2(eee, 18.0f);
            //Scrolbarの幅に代入する
        }

        float sT = highJump * 10;//データでのジャンプ3.002 * 10 = 40.02
        //Debug.Log("ジャンプレベル" + sT);

        int ts;//int型の変数tsを宣言
        ts = (int)sT;//sTをint型に変換し変数tsに代入 小数点以下を消す　50.02となる
        int tt = ts + 10;
        //Debug.Log("2ジャンプレベル" + tt);

        string sst = tt.ToString();//tsをstring型変換し変数sstに代入
        //Debug.Log("3ジャンプレベル" + sst);
        jt.text = sst;//sstはstring型なのでtextに代入できる
    }
}