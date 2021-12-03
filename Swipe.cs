using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    /*プレイヤーの持つパラメータを参照*/
    private Vector3 pos;//プレイヤーの座標

    /*操作に関する処理*/
    private Vector3 touchStartPos;//画面タップ開始地点の座標
    private Vector3 touchNowPos;//現在の座標
    public string direction;//現在のタッチの状態を代入するstring
    private bool isTouch;//タッチされているかどうか
    private bool is55;//55以上
    private bool is65;//65以上
    private bool is75;//75以上
    private bool is85;//85以上
    private bool is95;//95以上
    private bool is105;//105以上

    /*動作に関する処理*/
    public bool isMove;//動いているかどうか
    [SerializeField] private float moveSpeed = 0.0f;//プレイヤーの移動速度
    
    //[Header("ステージ1-8")] public GameObject Stage1_8;

    //=================================
    //初期化
    //=================================
    void Start()
    {
        is55 = true;
    }

    //=================================
    //更新
    //=================================
    void Update()
    {
        if (isMove) { Move(); }//移動
        else { Flick(); }//フリックの処理
    }

    //=================================
    //フリック操作
    //=================================
    void Flick()
    {
        //画面がタップされた時
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            isTouch = true;
        }
        //画面から指が離れた時
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //タッチを検出
            if (direction == "touch")
            {
                //タッチの処理
                Debug.Log("タッチ");
            }
            isTouch = false;
        }

        //現在タッチされている場合
        if (isTouch)
        {
            touchNowPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GetDirection();//座標からタッチ、フリックの状態を管理
        }
    }

    //=================================
    //座標の管理
    //=================================
    void GetDirection()
    {
        //現在の座標と開始地点の座標の差を代入
        float directionX = touchNowPos.x - touchStartPos.x;
        float directionY = touchNowPos.y - touchStartPos.y;
        //Debug.Log("フリックX" + directionX);
        //Debug.Log("フリックY" + directionY);

        //差の大きさによって条件分岐
        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                
                
                //右向きにフリック　
                direction = "left";
            }
            else if (-30 > directionX)
            {
               
                
                //左向きにフリック
                direction = "right";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                direction = "down";
            }
        }

        //フリック操作がなかった場合
        else
        {
            //タッチを検出
            direction = "touch";
        }

        if (direction == null || direction == "touch") { return; }

        isTouch = false;
        isMove = true;
    }

    //=================================
    //移動
    //=================================
    void Move()
    {
        pos = transform.position;
        //フリックの方向によって分岐
        switch (direction)
        {
            case "up":
                //上フリックされた時の処理
                //pos.y += moveSpeed;
                break;

            case "down":
                //下フリックされた時の処理
                //pos.y -= moveSpeed;
                break;

            case "right":
                //左フリックされた時の処理 104より小さい場合
                if (pos.x <= 104)
                {
                    pos.x += moveSpeed;
                }
                break;

            case "left":
                //右フリックされた時の処理 56より大きい場合
                if (pos.x >= 56)
                {
                    pos.x -= moveSpeed;
                }
                break;
            //デフォルト処理
            default:
                //処理Default
                Debug.Log("Default");
                //break文
                break;
        }

        transform.position = pos;
        //Debug.Log("トランスフォームポジション" + transform.position);

        //位置Xが65以上になったら止まる
        if (pos.x >= 65 && is55)
        {
            direction = null;
            isMove = false;
            is65 = true;
            is55 = false;

            //Stage1-8
            GameObject[] tagobjs = GameObject.FindGameObjectsWithTag("Stage1-8");
            foreach (GameObject obj in tagobjs)
            {
                obj.SetActive(false);
            }
            //やじるし1
            GameObject[] myYaji1 = GameObject.FindGameObjectsWithTag("comsoon1");
            foreach (GameObject yobj1 in myYaji1)
            {
                GameObject myYaji0 = yobj1.transform.Find("yajirusi").gameObject;
                if (myYaji0 != null)
                {
                    myYaji0.SetActive(false);
                }
            }
            //やじるし２
            GameObject[] myYaji = GameObject.FindGameObjectsWithTag("comsoon");
            foreach (GameObject yobj in myYaji)
            {
                GameObject myYaji2 = yobj.transform.Find("yajirusi2").gameObject;
                if (myYaji2 != null)
                {
                    myYaji2.SetActive(true);
                }
            }
            //Stage9-16
            GameObject[] myButtonB = GameObject.FindGameObjectsWithTag("StageB");
            foreach (GameObject objB in myButtonB)
            {
                GameObject myButtonBB = objB.transform.Find("Button").gameObject;
                if (myButtonBB != null)
                {
                    myButtonBB.SetActive(true);
                }
            }

        }
            //位置Xが55以下になったら止まる
            if (pos.x <= 55)
        {
            direction = null;
            isMove = false;
            is65 = false;
            is55 = true;

            //Stage1-8
            GameObject[] myButton = GameObject.FindGameObjectsWithTag("StageA");
            foreach (GameObject obj in myButton)
            {
                GameObject myButton2 = obj.transform.Find("Button").gameObject;
                if (myButton2 != null)
                {
                    myButton2.SetActive(true);
                }
            }
            //やじるし1
            GameObject[] myYaji1 = GameObject.FindGameObjectsWithTag("comsoon1");
            foreach (GameObject yobj1 in myYaji1)
            {
                GameObject myYaji0 = yobj1.transform.Find("yajirusi").gameObject;
                if (myYaji0 != null)
                {
                    myYaji0.SetActive(true);
                }
            }
            //やじるし２
            GameObject[] myYaji = GameObject.FindGameObjectsWithTag("comsoon");
            foreach (GameObject yobj in myYaji)
            {
                GameObject myYaji2 = yobj.transform.Find("yajirusi2").gameObject;
                if (myYaji2 != null)
                {
                    myYaji2.SetActive(false);
                }
            }
            //Stage9-16
            GameObject[] tagobjsB = GameObject.FindGameObjectsWithTag("Stage9-16");
            foreach (GameObject objB in tagobjsB)
            {
                objB.SetActive(false);
            }

        }
        //位置Xが75以上になったら止まる
        if (pos.x >= 75 && is65)
        {
            direction = null;
            isMove = false;
            is75 = true;
            is65 = false;

            //Stage9-16
            GameObject[] tagobjsB = GameObject.FindGameObjectsWithTag("Stage9-16");
            foreach (GameObject objB in tagobjsB)
            {
                objB.SetActive(false);
            }

            //やじるし２
            GameObject[] myYaji = GameObject.FindGameObjectsWithTag("comsoon");
            foreach (GameObject yobj in myYaji)
            {
                GameObject myYaji2 = yobj.transform.Find("yajirusi2").gameObject;
                if (myYaji2 != null)
                {
                    myYaji2.SetActive(false);
                }
            }

            //やじるし3
            GameObject[] myYaji3 = GameObject.FindGameObjectsWithTag("comsoon3");
            foreach (GameObject yobj3 in myYaji3)
            {
                GameObject MYYaji3 = yobj3.transform.Find("yajirusi3").gameObject;
                if (MYYaji3 != null)
                {
                    MYYaji3.SetActive(true);
                }
            }

            

        }
        //位置Xが85以上になったら止まる
        if (pos.x >= 85 && is75)
        {
            direction = null;
            isMove = false;
            is85 = true;
            is75 = false;

            //やじるし3
            GameObject[] myYaji3 = GameObject.FindGameObjectsWithTag("comsoon3");
            foreach (GameObject yobj3 in myYaji3)
            {
                GameObject MYYaji3 = yobj3.transform.Find("yajirusi3").gameObject;
                if (MYYaji3 != null)
                {
                    MYYaji3.SetActive(false);
                }
            }
            //やじるし4
            GameObject[] myYaji4 = GameObject.FindGameObjectsWithTag("comsoon4");
            foreach (GameObject yobj4 in myYaji4)
            {
                GameObject MYYaji4 = yobj4.transform.Find("yajirusi4").gameObject;
                if (MYYaji4 != null)
                {
                    MYYaji4.SetActive(true);
                }
            }
            

        }
        //位置Xが95以上になったら止まる
        if (pos.x >= 95 && is85)
        {
            direction = null;
            isMove = false;
            is95 = true;
            is85 = false;

            //やじるし4
            GameObject[] myYaji4 = GameObject.FindGameObjectsWithTag("comsoon4");
            foreach (GameObject yobj4 in myYaji4)
            {
                GameObject MYYaji4 = yobj4.transform.Find("yajirusi4").gameObject;
                if (MYYaji4 != null)
                {
                    MYYaji4.SetActive(false);
                }
            }
            //やじるし5
            GameObject[] myYaji5 = GameObject.FindGameObjectsWithTag("comsoon5");
            foreach (GameObject yobj5 in myYaji5)
            {
                GameObject MYYaji5 = yobj5.transform.Find("yajirusi5").gameObject;
                if (MYYaji5 != null)
                {
                    MYYaji5.SetActive(true);
                }
            }
           
        }
        //位置Xが95以下になったら止まる
        if (pos.x <= 95 && is105)
        {
            direction = null;
            isMove = false;
            is95 = true;
            is105 = false;

            
            //やじるし5
            GameObject[] myYaji5 = GameObject.FindGameObjectsWithTag("comsoon5");
            foreach (GameObject yobj5 in myYaji5)
            {
                GameObject MYYaji5 = yobj5.transform.Find("yajirusi5").gameObject;
                if (MYYaji5 != null)
                {
                    MYYaji5.SetActive(true);
                }
            }
            //やじるし6
            GameObject[] myYaji6 = GameObject.FindGameObjectsWithTag("comsoon6");
            foreach (GameObject yobj6 in myYaji6)
            {
                GameObject MYYaji6 = yobj6.transform.Find("yajirusi6").gameObject;
                if (MYYaji6 != null)
                {
                    MYYaji6.SetActive(false);
                }
            }
        }
        //位置Xが85以下になったら止まる
        if (pos.x <= 85 && is95)
        {
            direction = null;
            isMove = false;
            is85 = true;
            is95 = false;

            

            //やじるし4
            GameObject[] myYaji4 = GameObject.FindGameObjectsWithTag("comsoon4");
            foreach (GameObject yobj4 in myYaji4)
            {
                GameObject MYYaji4 = yobj4.transform.Find("yajirusi4").gameObject;
                if (MYYaji4 != null)
                {
                    MYYaji4.SetActive(true);
                }
            }
            //やじるし5
            GameObject[] myYaji5 = GameObject.FindGameObjectsWithTag("comsoon5");
            foreach (GameObject yobj5 in myYaji5)
            {
                GameObject MYYaji5 = yobj5.transform.Find("yajirusi5").gameObject;
                if (MYYaji5 != null)
                {
                    MYYaji5.SetActive(false);
                }
            }
        }
        //位置Xが75以下になったら止まる
        if (pos.x <= 75 && is85)
        {
            direction = null;
            isMove = false;
            is75 = true;
            is85 = false;

           

            //やじるし3
            GameObject[] myYaji3 = GameObject.FindGameObjectsWithTag("comsoon3");
            foreach (GameObject yobj3 in myYaji3)
            {
                GameObject MYYaji3 = yobj3.transform.Find("yajirusi3").gameObject;
                if (MYYaji3 != null)
                {
                    MYYaji3.SetActive(true);
                }
            }
            //やじるし4
            GameObject[] myYaji4 = GameObject.FindGameObjectsWithTag("comsoon4");
            foreach (GameObject yobj4 in myYaji4)
            {
                GameObject MYYaji4 = yobj4.transform.Find("yajirusi4").gameObject;
                if (MYYaji4 != null)
                {
                    MYYaji4.SetActive(false);
                }
            }

        }
        //位置Xが65以下になったら止まる
        if (pos.x <= 65 && is75)
        {
            direction = null;
            isMove = false;
            is65 = true;
            is75 = false;

            //Stage9-16
            GameObject[] myButtonB = GameObject.FindGameObjectsWithTag("StageB");
            foreach (GameObject objB in myButtonB)
            {
                GameObject myButtonBB = objB.transform.Find("Button").gameObject;
                if (myButtonBB != null)
                {
                    myButtonBB.SetActive(true);
                }
            }

            //やじるし２
            GameObject[] myYaji = GameObject.FindGameObjectsWithTag("comsoon");
            foreach (GameObject yobj in myYaji)
            {
                GameObject myYaji2 = yobj.transform.Find("yajirusi2").gameObject;
                if (myYaji2 != null)
                {
                    myYaji2.SetActive(true);
                }
            }
            //やじるし3
            GameObject[] myYaji3 = GameObject.FindGameObjectsWithTag("comsoon3");
            foreach (GameObject yobj3 in myYaji3)
            {
                GameObject MYYaji3 = yobj3.transform.Find("yajirusi3").gameObject;
                if (MYYaji3 != null)
                {
                    MYYaji3.SetActive(false);
                }
            }
        }
        //位置Xが105以上になったら止まる
        if (pos.x >= 105)
        {
            direction = null;
            isMove = false;
            is105 = true;
            is95 = false;

            //やじるし5
            GameObject[] myYaji5 = GameObject.FindGameObjectsWithTag("comsoon5");
            foreach (GameObject yobj5 in myYaji5)
            {
                GameObject MYYaji5 = yobj5.transform.Find("yajirusi5").gameObject;
                if (MYYaji5 != null)
                {
                    MYYaji5.SetActive(false);
                }
            }

            //やじるし6
            GameObject[] myYaji6 = GameObject.FindGameObjectsWithTag("comsoon6");
            foreach (GameObject yobj6 in myYaji6)
            {
                GameObject MYYaji6 = yobj6.transform.Find("yajirusi6").gameObject;
                if (MYYaji6 != null)
                {
                    MYYaji6.SetActive(true);
                }
            }
        }
    }

    

    //=================================
    //初期座標に戻る
    //=================================
    public void Reset()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        direction = null;
        isMove = false;
    }
}