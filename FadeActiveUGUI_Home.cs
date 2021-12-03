using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeActiveUGUI_Home : MonoBehaviour
{
    [Header("フェードスピード")] public float speed = 1.0f;
    [Header("上昇量")] public float moveDis = 1.0f;
    [Header("上昇時間")] public float moveTime = 0.3f;
    [Header("キャンバスグループ")] public CanvasGroup cg;
    [Header("リトライ時に鳴らすSE")] public AudioClip retrySE;

    private Vector3 defaltPos;
    private float timer = 0.0f;
    [HideInInspector] public bool isHome = false;
    [HideInInspector] public bool isNo = false;

    public void Start()
    {
        //初期化
        if (cg == null)
        {
            Debug.Log("インスペクターの設定が足りません");
            Destroy(this);
        }
        else
        {
            cg.alpha = 0.0f;
            defaltPos = cg.transform.position;
            cg.transform.position = defaltPos - Vector3.up * moveDis;
        }
    }
    public void Update()
    {
        //Homeボタンを押された
        if (isHome)
        {
            //上降しながらフェードインする
            if (cg.transform.position.y < defaltPos.y || cg.alpha < 1.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position += Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer += speed * Time.deltaTime;
            }
            //フェードイン完了
            else if (!isHome)
            {
                cg.alpha = 1.0f;
                cg.transform.position = defaltPos;
            }
        }
        //いいえボタンを押された
        else if (isNo)
        {
            //下昇しながらフェードアウトする
            if (cg.transform.position.y > defaltPos.y - moveDis || cg.alpha > 0.0f)
            {
                cg.alpha = timer / moveTime;
                cg.transform.position -= Vector3.up * (moveDis / moveTime) * speed * Time.deltaTime;
                timer -= speed * Time.deltaTime;
            }
            //フェードアウト完了
            else
            {
                timer = 0.0f;
                cg.alpha = 0.0f;
                cg.transform.position = defaltPos - Vector3.up * moveDis;
            }
        }
    }
    /// <summary>
    /// Homeボタンを押された
    /// </summary>
    public void Home()
    {
        cg.transform.localPosition = new Vector3(80f, -482f, 0.0f); // 座標を変更
        isHome = true;
        Debug.Log("Home  isHome" + isHome);
        isNo = false;
    }

    /// <summary>
    /// 最初から始める
    /// </summary>
    public void Retry()
    {
        GManager.instance.PlaySE(retrySE); //New!
        GManager.instance.RetryGame();
        SceneManager.LoadScene("ButtonScene");
        Time.timeScale = 1.0f;
    }
    /// <summary>
    /// やっぱやめる
    /// </summary>
    public void Return()
    {
        isNo = true;
        isHome = false;
        Debug.Log("Return  isHome" + isHome);

        cg.alpha = 0.0f;
        defaltPos = cg.transform.position;
        cg.transform.position = defaltPos - Vector3.up * moveDis;
    }
}