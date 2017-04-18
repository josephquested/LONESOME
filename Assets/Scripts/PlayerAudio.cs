using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

	// SYSTEM //

	public AudioSource breatheAudio;
	public AudioSource expressionAudio;

	// CONTROLS //

	public void SetExpressionClip (AudioClip clip, float volume, float pitch)
	{
		expressionAudio.clip = clip;
		expressionAudio.volume = volume;
		expressionAudio.pitch = pitch;
	}

	public void PlayExpression ()
	{
		expressionAudio.Play();
	}

	// COMMON AUDIO //

	public AudioClip breathingClip;

	public void Breathe (bool shouldBreathe)
	{
		if (shouldBreathe && !breatheAudio.isPlaying)
		{
			breatheAudio.Play();
		}
		else
		{
			breatheAudio.Stop();
		}
	}
}
