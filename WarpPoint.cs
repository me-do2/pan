using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    private ObjectCollision oc;
    private Animator anim;
    //public Vector3 pos;
    [Header("プレイヤーオブジェクト")] public GameObject playerObj;
    [Header("ワープ位置")] public GameObject warpPoint;
    [Header("自動ドアSE")] public AudioClip jdoaSE;
    [HideInInspector] public bool isWarp = false;
    [HideInInspector] public bool warpOK = false;
    [HideInInspector] public bool warpEx = false;
    [HideInInspector] public bool warpEnd = false;
    [HideInInspector] public bool warpppp = false;
    [Header("カメラ切り替え")] public bool CMvcam = false;
    [Header("カメラ１")] public GameObject vcam1 = null;
    [Header("カメラ2")] public GameObject vcam2 = null;
    [Header("BGM切り替え")] public bool BGMchange = false;
    [Header("BGM１")] public GameObject bgm1 = null;
    [Header("BGM2")] public GameObject bgm2 = null;
    [Header("ボス出現")] public bool BOSSon = false;
    [Header("ボスオブジェクト")] public GameObject BOSSobj = null;
    

    private float scaleXYZ = 1.0f;
    private float span2 = 0.05f;
    
    void Start()
    {
        oc = GetComponent<ObjectCollision>();
        anim = GetComponent<Animator>();
        if (oc == null || anim == null)
        {
            Debug.Log("ワープドアの設定が足りていません");
            Destroy(this);
        }
        if (BGMchange)
        {
            bgm1.SetActive(true);
            bgm2.SetActive(false);
        }
    }

    void Update()
    {
        if (oc.playerStepOn && !warpEnd)
        {
            warpEx = true;
            anim.SetTrigger("on");
            oc.playerStepOn = false;
            if (GManager.instance != null)
            {
                GManager.instance.PlaySE(jdoaSE);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isWarp = true;
        if (isWarp && anim != null)
        {
            //warpdoor_openアニメーションが完了しているかどうか
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (currentState.IsName("warpdoor_open"))
            {
                //Debug.Log("currentState.normalizedTime" + currentState.normalizedTime);
                if (currentState.normalizedTime >= 0.4f)//終了時間が0.99となる為、１では通らない
                {
                    if (!warpppp && isWarp)
                    {
                        scaleXYZ += -0.1f;
                        playerObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
                        //Debug.Log("scaleXYZ" + scaleXYZ);
                        // ぱんちゃんの大きさが0.1以下にならないようにする
                        if (scaleXYZ <= 0.1f)//scaleXYZが0.2f以下のときtrue
                        {
                            //Debug.Log("scaleXYZが0.2f以下のときtrue" + scaleXYZ);
                            isWarp = false;
                            scaleXYZ = 0.1f;
                            playerObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
                            warpOK = true;
                        }
                    }
                    if (!warpppp && warpOK)
                    {
                        warpppp = true;
                        playerObj.gameObject.transform.position = warpPoint.transform.position;//ワープする
                        Debug.Log("ワープ完了");

                        InvokeRepeating("Logging2", span2, span2);
                        Invoke("Logging", 1);//1秒後にvoid Logging()を実行する
                        Invoke("Logging3", 3.1f);//3.1秒後にvoid Logging3()を実行する
                        

                        if (CMvcam)
                        {
                            CMvcam = false;
                            vcam1.SetActive(false);
                            vcam2.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    void Logging2()
    {
        scaleXYZ += 0.1f;
        playerObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
        //Debug.Log("scaleXYZ2" + scaleXYZ);
        // 指定した大きさ以上にならないようにする
        if (scaleXYZ >= 1.0f)
        {
            scaleXYZ = 1.0f;
            playerObj.transform.localScale = new Vector3(scaleXYZ, scaleXYZ, scaleXYZ);
            //Debug.Log("指定した大きさ以上にならないようにする" + scaleXYZ);
        }
    }

    void Logging()
    {
        //Invokeで実行しているLogging2関数を停止する
        CancelInvoke("Logging2");
        warpOK = false;
        warpEnd = false;
        //Debug.Log("Logging");
    }

    void Logging3()
    {
        if (BOSSon)
        {
            BOSSobj.SetActive(true);
        }
        if (BGMchange)
        {
            BGMchange = false;
            bgm1.SetActive(false);
            bgm2.SetActive(true);
        }   
    }
}