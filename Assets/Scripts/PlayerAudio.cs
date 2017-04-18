using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

	// SYSTEM //

	AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// CONTROLS //

	public void SetAudioClip (AudioClip clip, float volume, float pitch)
	{
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.pitch = pitch;
	}

	public void Play ()
	{
		audioSource.Play();
	}

	public void Stop ()
	{
		audioSource.Stop();
	}

	// COMMON AUDIO //

	public AudioClip breathingClip;

	public void Breathe ()
	{
		SetAudioClip(breathingClip, 0.2f, 6f);
		Play();
	}
}
