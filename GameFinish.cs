using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1.UIシステムを使うときに必要なライブラリ
using UnityEngine.UI;
// 2.Scene関係の処理を行うときに必要なライブラリ
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    [Header("現在のステージ")] public int stage;
    [Header("現在のステージ")] public int stageNum;
    // 3.OnRetry関数が実行されたら、sceneを読み込む
    public void OnRetry()
    {
        Time.timeScale = 1f;
        // 「ButtonScene」を自分の読み込みたいscene名に変える
        SceneManager.LoadScene("stage" + stage);
        GManager.instance.stageNum = stage;
    }
}