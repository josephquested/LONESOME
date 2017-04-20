using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstChamberController : MonoBehaviour {

	// SYSTEM //

	public Candle candle1;
	public Candle candle2;

	void Update ()
	{
		MoveToTarget(GetTarget());
		UpdateLight();
		UpdateOpenness();
		UpdateAudio();
	}

	void MoveToTarget (Vector3 target)
	{
		float step = speed * Time.deltaTime;
		door.transform.position = Vector3.MoveTowards(door.transform.position, target, step);
	}

	// DOOR //

	public Transform door;

	public int openness = 0;
	public float speed;

	public Vector3 halfGoal;
	public Vector3 fullGoal;

	void UpdateOpenness ()
	{
		if (!candle1.lit && !candle2.lit)
		{
			openness = 2;
		}
		else
		{
			if (!candle1.lit || !candle2.lit)
			{
				openness = 1;
			}
		}
	}

	Vector3 GetTarget ()
	{
		if (openness == 1)
		{
			return halfGoal;
		}
		if (openness == 2)
		{
			return fullGoal;
		}
		else
		{
			return door.transform.position;
		}
	}

	// AUDIO //

	public AudioSource openAudio;
	public AudioSource slamAudio;

	bool firstStop;
	bool lastStop;

	void UpdateAudio ()
	{
		if (door.transform.position == halfGoal && !firstStop)
		{
			firstStop = true;
			slamAudio.Play();
		}
		if (door.transform.position == fullGoal && !lastStop)
		{
			lastStop = true;
			slamAudio.Play();
		}
		if (GetTarget() != door.transform.position)
		{
			openAudio.volume += 0.25f;
		}
		if (GetTarget() == door.transform.position)
		{
			openAudio.volume -= 0.25f;
		}
	}

	// CANDLE //

	IEnumerator LightOutRoutine ()
	{
		yield return new WaitForSeconds(10f);
		if (candle2.lit && candle1.lit)
		{
			candle2.Fire();
			openness++;
		}
	}

	// LIGHT //

	public Light spotLight;
	public float lightSpeed;

	void UpdateLight ()
	{
		if (openness == 1 && spotLight.range < 4)
		{
			spotLight.range += lightSpeed;
		}
		if (openness == 2 && spotLight.range < 8)
		{
			spotLight.range += lightSpeed;
		}
	}

	// TRIGGERS //

	bool playerTriggered = false;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player" && !playerTriggered)
		{
			playerTriggered = true;
			StartCoroutine(LightOutRoutine());
		}
	}
}
