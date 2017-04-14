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

	void FixedUpdate ()
	{
		UpdateAxis();
	}

	void Update ()
	{
		UpdateLockDirection();
		UpdateInteract();
	}

	// INPUT //

	void UpdateAxis ()
	{
		sm.ReceiveAxisInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void UpdateLockDirection ()
	{
		sm.ReceiveLockDirectionInput(Input.GetButton("LockDirection"));
	}

	void UpdateInteract ()
	{
		sm.ReceiveInteractInput(Input.GetButton("Interact"), Input.GetButtonDown("Interact"), Input.GetButtonUp("Interact"));
	}
}
