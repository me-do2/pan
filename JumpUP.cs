using UnityEngine;
using UnityEngine.UI;

public class JumpUP : MonoBehaviour
{

    [Header("加算するジャンプ")] public float myJump;
    [Header("加算するジャンプの上限")] public float endJump;
    [Header("プレイヤーの判定")] public PlayerTriggerCheck playerCheck;

    private Text jumpText = null;
    private float oldJump = 4;
    public Text highJumpText; //ハイジャンプを表示するText
    private float highJump; //ハイジャンプ用変数
    private string key = "HIGH JUMP"; //ハイジャンプの保存先キー
    private bool hs = true;


    // Start is called before the first frame update
    void Start()
    {
        highJump = PlayerPrefs.GetFloat(key, 4.0001f);
        //保存しておいたハイジャンプをキーで呼び出し取得し保存されていなければ3になる

        highJumpText.text = highJump.ToString();
        jumpText = GetComponent<Text>();

        if (Player.instance != null)
        {
            Player.instance.jumpHeight = highJump;
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
                    if (endJump > highJump)
                    {
                        Player.instance.jumpHeight += myJump;
                        oldJump = Player.instance.jumpHeight;
                    }
                    else
                        hs = false;
                }
                //ハイジャンプより現在のジャンプが高い時
                if (oldJump > highJump & hs)
                {

                    highJump = oldJump;
                    //ハイジャンプ更新

                    PlayerPrefs.SetFloat(key, highJump);
                    //ハイジャンプを保存

                    highJumpText.text = "JUMP UP" + highJump.ToString();
                    //ハイジャンプを表示
                    hs = false; 
                }
            }
        }
    }
}
