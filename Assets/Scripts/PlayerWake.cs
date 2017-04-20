using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWake : MonoBehaviour {

	// SYSTEM //

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<PlayerAudio>();
		GetComponent<SpriteRenderer>().material = wakeMaterial;
		if (startAwake) { Wake(); }
	}

	void Update ()
	{
		if (Input.anyKey && !waking)
		{
			waking = true;
			StartCoroutine(WakeRoutine());
		}
	}

	// WAKING //

	bool waking = false;

	public bool startAwake;

	public GameObject playerEyes;

	public Material wakeMaterial;
	public Material idleMaterial;

	IEnumerator WakeRoutine ()
	{
		anim.SetTrigger("Wake");
		StartCoroutine(WhimperRoutine());
		yield return new WaitForSeconds(7.75f);
		SnuffLightSource();
		while (AnimatorIsPlaying("player-wake")) { yield return null; }
		Wake();
	}

	void Wake ()
	{
		playerEyes.SetActive(true);
		GetComponent<SpriteRenderer>().material = idleMaterial;
		GetComponent<PlayerInput>().enabled = true;
		anim.SetBool("Idle", true);
		this.enabled = false;
	}

	// AUDIO //

	PlayerAudio playerAudio;

	public AudioClip whimperClip;

	IEnumerator WhimperRoutine ()
	{
		yield return new WaitForSeconds(5.80f);
		playerAudio.SetExpressionClip(whimperClip, 0.1f, 0.95f);
		playerAudio.PlayExpression();
	}

	// SCENE //

	public Interactable lightSource;

	void SnuffLightSource ()
	{
		lightSource.GetComponent<Interactable>().Fire();
	}

	// ANIMATOR //

	bool AnimatorIsPlaying (string stateName)
	{
	  return anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}
}
