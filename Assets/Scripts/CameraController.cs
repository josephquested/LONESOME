using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;

	public bool trackPlayer;

	void Update ()
	{
		if (trackPlayer)
		{
			TrackPlayer();
		}
	}

	void TrackPlayer ()
	{
		Vector3 position = new Vector3(player.position.x, player.position.y, -10);
		transform.position = position;
	}
}
