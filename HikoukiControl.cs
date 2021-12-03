using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikoukiControl : MonoBehaviour
{
	public float speed;
	[Header("plyer2X位置")] public float plyer2X = 17.0f;
	[Header("X最小")] public float itiXS = 5.0f;
	[Header("X最大")] public float itiXL = 29.0f;
	//[Header("カメラコライダー2")] public GameObject CC2;
	[Header("ムーブオブジェクト３CS")] public MoveObject3 MO3;
	public Vector2 myVelocity = Vector2.zero;

	[Header("ジョイスティック")] public VariableJoystick joystick;
	[Header("左ボタン確認")] public GameObject LeftButton;
	
	[Header("playerオブジェクト")] public GameObject playER;
	[HideInInspector] public SpriteRenderer sr = null;
	private float blinkTime = 0.0f;
	private float continueTime = 0.0f;
	private bool isContinue = false;

	private bool LButton = false;
	private Player pl;

	private Animator anim = null;

	[Header("ボールボタン3")] public BallButtonH BallBH3;
	[Header("ボールボタン4")] public BallButtonH BallBH4;
	private bool isThrowing = false;
	private bool isThrowing2 = false;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		//アニメーションを適用
		SetAnimation();
	}

	private void SetAnimation()
	{
		anim.SetBool("throwing", isThrowing);
		anim.SetBool("throwing2", isThrowing2);
	}

	void Update()
	{
		LButton = (LeftButton.activeSelf);
		if (!LButton)
		{
			float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
			//Debug.Log("moveX" + moveX);
			float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
			//Debug.Log("moveY" + moveY);

			//ムーブオブジェクト３CSからべくたー２の情報を持ってくる
			myVelocity = MO3.oldPos;
			//Debug.Log("myVelocity" + myVelocity);
			//X位置の情報しかいらないのでXだけ抜き出す
			float MVX = myVelocity.x;
			//Debug.Log("MVX" + MVX);
			//Player2のデフォルトX位置を引く
			float mmvx = MVX - plyer2X;

			transform.position = new Vector2(
				//エリア指定して移動する mmvxを足す
				Mathf.Clamp(transform.position.x + moveX, itiXS + mmvx, itiXL + mmvx),
				Mathf.Clamp(transform.position.y + moveY, -4.5f, 35.0f)
				);
		}
		else if (LButton)
		{
			float moveX = joystick.Horizontal * Time.deltaTime * speed;
			float moveY = joystick.Vertical * Time.deltaTime * speed;
			myVelocity = MO3.oldPos;
			float MVX = myVelocity.x;
			float mmvx = MVX - plyer2X;
			transform.position = new Vector2(
				Mathf.Clamp(transform.position.x + moveX, itiXS + mmvx, itiXL + mmvx),
				Mathf.Clamp(transform.position.y + moveY, -4.5f, 35.0f)
				);
		}
		playER.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f); // playerの座標を変更
		pl = GameObject.Find("Player").GetComponent<Player>();
		pl.sr.enabled = false; // playerのスプライトレンダラーを常に非アクティブにする

		if (pl.downPan)
        {
			//anim.SetFloat("HikoukiSpeed", 0.0f); // 一時停止
			anim.Play("hikouki_down");
			isContinue = true;
		}
		else
	    sr.enabled = true;

		if (isContinue && pl.downPan == false)
		{
			anim.Play("hikouki");
			//anim.SetFloat("HikoukiSpeed", 1.0f); // 再開

			//明滅　ついている時に戻る
			if (blinkTime > 0.2f)
			{
				sr.enabled = true;
				blinkTime = 0.0f;
			}
			//明滅　消えているとき
			else if (blinkTime > 0.1f)
			{
				sr.enabled = false;
			}
			//明滅　ついているとき
			else
			{
				sr.enabled = true;
			}
			//1秒たったら明滅終わり
			if (continueTime > 1.0f)
			{
				isContinue = false;
				blinkTime = 0.0f;
				continueTime = 0.0f;
				sr.enabled = true;
			}
			else
			{
				blinkTime += Time.deltaTime;
				continueTime += Time.deltaTime;
			}
		}

		if (BallBH3.BThrowing)
        {
			BallBH3.BThrowing = false;
			anim.Play("hikouki_throwing");
			isThrowing = true;
		}

		if (isThrowing && anim != null)
		{
			//スローイングアニメーションが完了しているかどうか
			AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
			if (currentState.IsName("hikouki_throwing"))
			{
				if (currentState.normalizedTime >= 0.55f)
				{
					isThrowing = false;
					//Debug.Log(“スローイングアニメーション完了");
				}
			}
		}

		if (BallBH4.BThrowing)
		{
			BallBH4.BThrowing = false;
			anim.Play("hikouki_throwing2");
			isThrowing2 = true;
		}

		if (isThrowing2 && anim != null)
		{
			//スローイング2アニメーションが完了しているかどうか
			AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
			if (currentState.IsName("hikouki_throwing2"))
			{
				if (currentState.normalizedTime >= 0.55f)
				{
					isThrowing2 = false;
					//Debug.Log(“スローイング2アニメーション完了");
				}
			}
		}
	}
}
