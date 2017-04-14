using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Interactable {

	public Light light1;
	public Light light2;

	public override void Fire ()
	{
		GetComponent<Animator>().SetTrigger("Snuff");
		light1.enabled = false;
		light2.enabled = false;
	}
}
