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

	public float breathVolume;

	public void Breathe (bool shouldBreathe)
	{
		if (shouldBreathe && breatheAudio.volume < breathVolume)
		{
			breatheAudio.volume += 0.01f;
		}
		if (!shouldBreathe && breatheAudio.volume > 0)
		{
			breatheAudio.volume -= 0.01f;
		}
	}
}
