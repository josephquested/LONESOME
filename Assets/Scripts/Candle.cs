using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Interactable {

	public Light light1;
	public Light light2;

	public AudioSource humAudio;

	public float fadeSpeed;

	public override void Fire ()
	{
		GetComponent<Animator>().SetTrigger("Snuff");
		GetComponent<AudioSource>().Play();
		StartCoroutine(FadeOutLightRoutine(light1));
		StartCoroutine(FadeOutLightRoutine(light2));
		Destroy(humAudio);
	}

	IEnumerator FadeOutLightRoutine (Light light)
	{
		while (light.range >= 0)
		{
			light.range -= fadeSpeed;
			yield return new WaitForSeconds(0.01f);
		}
	}
}
