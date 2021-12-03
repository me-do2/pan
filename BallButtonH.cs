using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BallButtonH : MonoBehaviour
{
    [Header("サッカーボールH")] public GameObject soccerBallH;
    [Header("出現ポイント")] public GameObject ContinueH;
    [HideInInspector] public bool BThrowing = false;
    [HideInInspector] public ButtonHandler ButHan;
    private float scaleXYZ = 1.0f;
    private bool isSpace = false;

    void Start()
    {
        ButHan = GetComponent<ButtonHandler>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnClick();
            isSpace = true;
        }

        if (ButHan.osita)
        {
            scaleXYZ += 0.1f;
            soccerBallH.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            if (scaleXYZ >= 3.0f) // 3以上にならないようにする
            {
                scaleXYZ = 3.0f;
            }
        }
        else
        {
            scaleXYZ = 1.0f;
        }
    }

    public void OnClick()
    {
        if (ButHan.hanasita  || isSpace)
        {
            isSpace = false;
            GameObject ContentItem = ContinueH;
            GameObject cloneObject = Instantiate(soccerBallH, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            cloneObject.transform.parent = ContentItem.transform;
            BThrowing = true;
            cloneObject.transform.localPosition = new Vector3(0.0f, 0.1f, 0.0f); // 座標を変更
            cloneObject.name = "soccerBallH3"; // クローンしたオブジェクトの名前を変更
            cloneObject.gameObject.transform.parent = null;//離縁
        }
        else
        {
            //Debug.LogFormat("ボタン離されてない");
        }
    }
}
