using UnityEngine;
using System.Collections;

public class AppearSE : MonoBehaviour
{

	private AudioSource audioSource;
	//　鳴らす音声クリップ
	private AudioClip appearSE = null;

	void Start()
	{
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.PlayOneShot(appearSE);
	}
}