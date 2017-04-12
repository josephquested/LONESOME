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
	}

	void Update ()
	{
		UpdateMovement();
		UpdateDirection();
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

	float vertical;
	float horizontal;

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			if (CanMove())
			{
				movement.ReceiveAxisInput(horizontal, vertical);
			}
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
			// change direction direction
		}
	}

	public void AttemptTurn (Directions newDirection)
	{
		if (!directionLock)
		{
			direction = newDirection;
		}
	}
}
