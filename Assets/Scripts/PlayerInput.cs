using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	StateMachine sm;

	void Start ()
	{
		sm = GetComponent<StateMachine>();
	}

	void Update ()
	{
		UpdateAxis();
		UpdateDirectionLock();
	}

	void UpdateAxis ()
	{
		sm.ReceiveAxisInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void UpdateDirectionLock ()
	{
		sm.ReceiveDirectionLockInput(Input.GetButton("DirectionLock"));
	}
}
