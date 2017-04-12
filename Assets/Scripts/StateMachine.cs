using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum States { Break, Idle };
public enum Directions { North, East, South, West };

public class StateMachine : MonoBehaviour {

	public States state = States.Idle;
	public Directions direction = Directions.South;

	// SYSTEM //

	void Start ()
	{
		movement = GetComponent<Movement>();
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		UpdateMovement();
		UpdateDirection();
		UpdateAnimator();
	}

	// INPUT //

  public void ReceiveAxisInput (float _horizontal, float _vertical)
  {
    horizontal = _horizontal;
    vertical = _vertical;
  }

  public void ReceiveDirectionLockInput (bool _directionLock)
  {
    directionLock = _directionLock;
  }

	// STATE //

	void Transition (States _state)
	{
		state = _state;
	}

	public bool CanTransition (States newState)
	{
		switch (state)
		{
			case States.Break:
				return new int[] { 1 }.Contains((int)newState);

			case States.Idle:
				return new int[] { 0 }.Contains((int)newState);

			default:
				return false;
		}
	}

	// MOVEMENT //

	Movement movement;

	bool moving;

	float vertical;
	float horizontal;

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			if (CanMove())
			{
				moving = true;
				movement.ReceiveAxisInput(horizontal, vertical);
			}
		}
		else
		{
			moving = false;
		}
	}

	public bool CanMove ()
	{
		int[] moveableStates = new int[] { 1 };
		return moveableStates.Contains((int)state);
	}

	// DIRECTION //

	public bool directionLock;

	void UpdateDirection ()
	{
		if (!directionLock)
		{
			direction = GetFacingDirection();
		}
	}

	public void AttemptTurn (Directions newDirection)
	{
		if (!directionLock)
		{
			direction = newDirection;
		}
	}

	Directions GetFacingDirection ()
	{
		if (horizontal == 1)
		{
			return Directions.East;
		}
		if (horizontal == -1)
		{
			return Directions.West;
		}
		if (vertical == 1)
		{
			return Directions.North;
		}
		if (vertical == -1)
		{
			return Directions.South;
		}
		else
		{
			return direction;
		}
	}

	// ANIMATOR //\

	Animator anim;

	void UpdateAnimator ()
	{
		anim.SetBool("Moving", moving);
		anim.SetInteger("Direction", (int)direction);
	}
}
