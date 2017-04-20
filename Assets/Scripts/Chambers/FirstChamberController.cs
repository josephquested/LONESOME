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

	// CANDLE //

	IEnumerator LightOutRoutine ()
	{
		yield return new WaitForSeconds(5f);
		if (candle2.lit)
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
