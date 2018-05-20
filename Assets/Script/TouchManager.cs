using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collision2d = Physics2D.OverlapPoint (mousePos);
			if (collision2d != null) {
				GameObject tapObject = collision2d.transform.gameObject;
				if (tapObject.tag == "Card") {
					tapObject.GetComponent<Card> ().Use ();
				}
			}
		}
	}
}
