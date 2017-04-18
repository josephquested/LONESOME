﻿using System.Collections;
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
		if (Input.anyKey && !AnimatorIsPlaying("player-wake"))
		{
			StartCoroutine(WakeRoutine());
		}
	}

	// WAKING //

	public bool startAwake;

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
		playerAudio.Breathe();
		yield return new WaitForSeconds(5.80f);
		playerAudio.SetAudioClip(whimperClip, 0.075f, 0.85f);
		playerAudio.Play();
		yield return new WaitForSeconds(2.5f);
		playerAudio.Breathe();
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
