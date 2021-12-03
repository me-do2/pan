using UnityEngine;
using UnityEngine.UI;

public class JumpUP_ST : MonoBehaviour
{
    [Header("加算するジャンプ")] public float myJump;
    [Header("加算するジャンプの上限")] public float endJump;

    public Text highJumpText; //ハイジャンプを表示するText
    private float highJump; //ハイジャンプ用変数
    private string key = "HIGH JUMP"; //ハイジャンプの保存先キー

    // Start is called before the first frame update
    void Start()
    {
        highJump = PlayerPrefs.GetFloat(key, 4.0001f);
        //保存しておいたハイスピードをキーで呼び出し取得し保存されていなければ5になる
        highJumpText.text = highJump.ToString();

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
}
