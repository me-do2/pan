using UnityEngine;
using UnityEngine.UI;

public class HeartUP_ST : MonoBehaviour
{
    public Text highHeartText; //ハート力を表示するText
    private float highHeart; //ハート力用変数
    private string key = "HIGH HEAT"; //ハート力の保存先キー

    // Start is called before the first frame update
    void Start()
    {
        highHeart = PlayerPrefs.GetFloat(key, 3.0001f);
        //保存しておいたハート力をキーで呼び出し取得し保存されていなければ3.001になる
        highHeartText.text = highHeart.ToString();
    }
}
