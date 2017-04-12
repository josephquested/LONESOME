using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		_light = GetComponent<Light>();
		StartCoroutine(FlickerRoutine());
	}

	// FLICKER //

	Light _light;

	public bool flicker;

	public float minFlickerIntensity;
	public float maxFlickerIntensity;
	public float flickerSpeed;

	float randomizer = 0;

	IEnumerator FlickerRoutine ()
	{
		while (flicker)
		{
			if (randomizer == 0)
			{
				_light.intensity = Random.Range(minFlickerIntensity, maxFlickerIntensity);
			}
			else
			{
				_light.intensity = Random.Range(minFlickerIntensity, maxFlickerIntensity);
			}
			randomizer = Random.Range(0, 1.1f);
			yield return new WaitForSeconds(flickerSpeed);
		}
	}
}
