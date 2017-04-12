using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Animator animator;

	public float speed;

	void Start ()
	{
		animator = GetComponent<Animator>();
	}

	void Update ()
  {
		UpdateAnimator();
	}

  public void ReceiveAxisInput (float horizontal, float vertical)
  {
    Move(GetMovementVector(horizontal, vertical));
  }

	void Move (Vector2 movement)
	{
		transform.Translate(movement * speed);
	}

	Vector2 GetMovementVector (float vertical, float horizontal)
	{
		if (vertical != 0)
		{
			return new Vector2(0, vertical);
		}
		else
		{
			return new Vector2(horizontal, 0);
		}
	}

	void UpdateAnimator ()
	{
		// animator.SetBool("Moving", sm.state == States.Moving);
	}
}
