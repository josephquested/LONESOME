using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWake : MonoBehaviour {

	// SYSTEM //

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();
		GetComponent<SpriteRenderer>().material = wakeMaterial;
		if (startAwake) { Wake(); }
	}

	void Update ()
	{
		if (Input.anyKey)
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
		yield return new WaitForSeconds(1);
		while (AnimatorIsPlaying("player-wake")) { yield return null; }
		Wake();
	}

	void Wake ()
	{
		anim.SetBool("Idle", true);
		GetComponent<SpriteRenderer>().material = idleMaterial;
		GetComponent<PlayerInput>().enabled = true;
		this.enabled = false;
	}

	bool AnimatorIsPlaying (string stateName)
	{
	  return anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}
}
