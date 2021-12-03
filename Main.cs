using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

// メイン
public class Main : MonoBehaviour
{
    public VariableJoystick joystick;
    [Header("ATボタン")] public AxisTouchButton ATButton;
    [HideInInspector] public bool isMae = false;
    [HideInInspector] public bool isUsiro = false;

    // 更新時に呼ばれる
    void Update()
    {
        // ジョイスティックの状態表示
        //print("Horizontal: " + joystick.Horizontal);
        //print("Vertical: " + joystick.Vertical);

        if (joystick.Horizontal > 0)
        {
            isMae = true;
            isUsiro = false;
            ATButton.axisValue = 1;
            //Debug.Log("Main.isMae    " + isMae);
        }
        if (joystick.Horizontal < 0)
        {
            isUsiro = true;
            isMae = false;
            ATButton.axisValue = -1;
            //Debug.Log("Main.isUsiro    " + isUsiro);
        }
        if (joystick.Horizontal == 0)
        {
            isUsiro = false;
            isMae = false;
            //Debug.Log("Main.Horizontal0    " + joystick.Horizontal);
        }
    }
}