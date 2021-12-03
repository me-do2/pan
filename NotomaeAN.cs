using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotomaeAN : MonoBehaviour
{
    private Animator anim = null;

    private int myScoreM;
    private int myScoreS;
    private bool mSC = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GManager.instance.isStageClear)
        {
            anim.Play("notomae_win");
            Invoke("Hoge", 0);
        }
        if (mSC)
        {
            CancelInvoke();
        }
    }
    void Hoge()
    {
        myScoreM = RemainTimer.instance.minutes * 60;
        Debug.Log("スコア分" + myScoreM);
        myScoreS = RemainTimer.instance.seconds;
        Debug.Log("スコア秒" + myScoreS);
        GManager.instance.score += (myScoreM + myScoreS);
        mSC = true;   
    }
}
