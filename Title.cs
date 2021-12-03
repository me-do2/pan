using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Title : MonoBehaviour
{
    [Header("フェード")] public FadeImage fade;
    [Header("ゲームスタート時に鳴らすSE")] public AudioClip startSE;
    [Header("画面を押してねText")] public GameObject gOss;

    private bool firstPush = false;
    private bool goNextScene = false;

    void Start()
    {
        gOss.SetActive(false);
    }
        /// <summary>
        /// スタートボタンを押されたら呼ばれる
        /// </summary>
        public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            GManager.instance.PlaySE(startSE);
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    void Update()
    {
        if (!goNextScene && fade.IsFadeOutComplete())
        {
            SceneManager.LoadScene("ButtonScene");
            goNextScene = true;
        }
        Invoke("Logging", 10);//10秒後にvoid Logging()を実行する
    }
    void Logging()
    {
        gOss.SetActive(true);
    }
}