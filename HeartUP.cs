using UnityEngine;
using UnityEngine.UI;

public class HeartUP : MonoBehaviour
{

    [Header("加算するハート")] public float myHerrt;
    [Header("加算するハートの上限")] public float endHerrt;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;

    //private Text jumpText = null;
    private float oldHeart = 3;
    public Text highHeartText; //ハイハートを表示するText
    private float highHeart; //ハイハート用変数
    private string key = "HIGH HEAT"; //ハイハートの保存先キー
    private bool hs = true;

    private int a;//int型の変数aを宣言


    // Start is called before the first frame update
    void Start()
    {
        highHeart = PlayerPrefs.GetFloat(key, 3.0001f);
        //保存しておいたハイハートをキーで呼び出し取得し保存されていなければ3.001になる
        //Debug.Log("highHeart：" + highHeart);

        highHeartText.text = highHeart.ToString();
        //Debug.Log("highHeartText.text：" + highHeartText.text);

        //jumpText = GetComponent<Text>();
        //Debug.Log("jumpText：" + jumpText);

        a = (int)highHeart;//highHeartをint型に変換し変数aに代入
        //Debug.Log("a：" + a);

        Mathf.RoundToInt(a);//四捨五入してくれるメソッド【Mathf.RoundToInt】
        //Debug.Log("2a：" + a);

        if (GManager.instance != null)
        {
            GManager.instance.defaultHeartNum = a;
            GManager.instance.heartNum = a;
            //Debug.Log("3a：" + a);
        }
        else
        {
            //Debug.Log("ゲームマネージャ置き忘れてるよ！");
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
                if (GManager.instance != null)
                {
                    if (endHerrt > highHeart)
                    {
                        highHeart += myHerrt;//ハイハートに0.001を足す

                        oldHeart = GManager.instance.defaultHeartNum;
                        oldHeart = GManager.instance.heartNum;
                        //Debug.Log("oldHeart：" + oldHeart);

                        //oldハートよりハイハートが高い時
                        if (highHeart > oldHeart & hs)
                        {
                            
                            PlayerPrefs.SetFloat(key, highHeart);
                            //ハイハートを保存
                            a = (int)highHeart;//highHeartをint型に変換し変数aに代入
                            //Debug.Log("a：" + a);

                            Mathf.RoundToInt(a);//四捨五入してくれるメソッド【Mathf.RoundToInt】
                            //Debug.Log("2a：" + a);

                            GManager.instance.defaultHeartNum = a;
                            GManager.instance.heartNum = a;
                            //Debug.Log("4a：" + a);

                            oldHeart = highHeart;
                            //oldハート更新
                            //Debug.Log("highHeart：" + highHeart);

                            highHeartText.text = "HEAT UP" + oldHeart.ToString();
                            //oldハートを表示
                            hs = false;
                        }
                        else
                            hs = false;
                    }
                }
            }
        }
    }
}
