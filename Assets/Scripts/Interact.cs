using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	// INPUT //

	public void ReceiveDirectionInput (Directions direction)
	{
		Rotate(GetRotationFromDirection(direction));
		Position(GetPositionFromDirection(direction));
	}

	// INTERACT //

	public void Fire ()
	{
		print("fire!");
	}

	// ROTATION //

	void Rotate (Quaternion rotation)
	{
		transform.localRotation = rotation;
	}

	Quaternion GetRotationFromDirection (Directions direction)
	{
		switch (direction)
		{
			case Directions.North:
				return Quaternion.Euler(0, 0, 182.5f);

			case Directions.East:
				return Quaternion.Euler(0, 0, 90);

			case Directions.South:
				return Quaternion.Euler(0, 0, 0);

			case Directions.West:
				return Quaternion.Euler(0, 0, -90);

			default:
				return Quaternion.Euler(0, 0, 0);
		}
	}

	// POSITION //

	void Position (Vector3 position)
	{
		transform.localPosition = position;
	}

	Vector3 GetPositionFromDirection (Directions direction)
	{
		switch (direction)
		{
			case Directions.North:
				return new Vector3(0, 0.025f, 00);

			case Directions.East:
				return new Vector3(0, -0.15f, 0);

			case Directions.South:
				return new Vector3(0, 0, 0);

			case Directions.West:
				return new Vector3(0, -0.15f, 0);

			default:
				return new Vector3(0, 0, 0);
		}
	}
}
