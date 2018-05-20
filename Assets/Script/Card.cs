using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour {

	[HideInInspector]
	public UnityAction afterUse;
	[SerializeField]
	private CardEffect effect;

	public void Use() {
//		effect.use ();
		Destroy (gameObject);
		afterUse ();
	}
}
