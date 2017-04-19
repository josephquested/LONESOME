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
		interact = GetComponentInChildren<Interact>();
		playerAudio = GetComponent<PlayerAudio>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		UpdateMovement();
	}

	void Update ()
	{
		UpdateDirection();
		UpdateAnimator();
		UpdateInteract();
		UpdateBreathAudio();
	}

	// INPUT //

  public void ReceiveAxisInput (float _horizontal, float _vertical)
  {
    horizontal = _horizontal;
    vertical = _vertical;
  }

  public void ReceiveLockDirectionInput (bool _lockDirection)
  {
    lockDirection = _lockDirection;
  }

	public void ReceiveInteractInput (bool _interactButton, bool _interactDown, bool _interactUp)
	{
		interactButton = _interactButton;
		interactDown = _interactDown;
		// interactUp = _interactUp;
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

	float vertical;
	float horizontal;

	bool moving;

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

	// INTERACT //

	Interact interact;

	public bool interactButton;
	bool interactDown;
	// bool interactUp;

	void UpdateInteract ()
	{
		interact.ReceiveDirectionInput(direction);
		if (interactDown && state == States.Idle)
		{
			interact.Fire();
		}
	}

	// DIRECTION //

	public bool lockDirection;

	void UpdateDirection ()
	{
		if (!lockDirection)
		{
			direction = GetFacingDirection();
		}
	}

	public void AttemptTurn (Directions newDirection)
	{
		if (!lockDirection)
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

	// ANIMATOR //

	Animator anim;

	void UpdateAnimator ()
	{
		anim.SetInteger("Direction", (int)direction);
	}

	// AUDIO //

	PlayerAudio playerAudio;

	void UpdateBreathAudio ()
	{
		playerAudio.Breathe(moving);
	}
}
