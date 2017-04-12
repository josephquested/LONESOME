using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

  // INPUT //

  public void ReceiveAxisInput (float horizontal, float vertical)
  {
    Move(GetMovementVector(horizontal, vertical));
  }

  // MOVEMENT //

  public float speed;

	void Move (Vector2 movement)
	{
		transform.Translate(movement * speed);
	}

	Vector2 GetMovementVector (float vertical, float horizontal)
	{
		if (vertical != 0)
		{
			return new Vector2(vertical, 0);
		}
		else
		{
			return new Vector2(0, horizontal);
		}
	}
}
