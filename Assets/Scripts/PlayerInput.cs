using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// SYSTEM //

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

	// INPUT //

	void UpdateAxis ()
	{
		sm.ReceiveAxisInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void UpdateDirectionLock ()
	{
		sm.ReceiveDirectionLockInput(Input.GetButton("DirectionLock"));
	}
}
