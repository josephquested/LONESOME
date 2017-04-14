using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public bool hot;

	public virtual void Fire ()
	{
		// override
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.GetComponent<Interact>() != null)
		{
			hot = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.GetComponent<Interact>() != null)
		{
			hot = false;
		}
	}
}
