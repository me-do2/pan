using UnityEngine;
using UnityEngine.UI;

public class KickUP_ST : MonoBehaviour
{
    public Text highKickText; //キック力を表示するText
    private float highKick; //キック力用変数
    private string key = "HIGH KICK"; //キック力の保存先キー

    // Start is called before the first frame update
    void Start()
    {
        highKick = PlayerPrefs.GetFloat(key, 2.0001f);
        //保存しておいたキック力をキーで呼び出し取得し保存されていなければ1になる
        highKickText.text = highKick.ToString();
    }
}
