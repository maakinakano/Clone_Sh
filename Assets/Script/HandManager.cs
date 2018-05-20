using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {

	private GameObject[] hands = new GameObject[GS.HAND_LIMIT];

	//cached
	private Vector2[] cardPos;

	//for demo
	[SerializeField]
	private GameObject cardPrefab;

	void Start () {
		cardPos = new Vector2[GS.HAND_LIMIT];
		Vector2 pos = transform.position;
		for (int i = 0; i < GS.HAND_LIMIT; i++) {
			cardPos [i] = new Vector2 (pos.x + (i - (GS.HAND_LIMIT / 2)) * GS.CARD_X, pos.y);
		}

		for (int i = 0; i < GS.HAND_LIMIT; i++) {
			GameObject card = Instantiate (cardPrefab, cardPos [i], Quaternion.identity);
			hands [i] = card;
			card.transform.parent = transform;
			card.GetComponent<Card> ().afterUse = () => {
				StartCoroutine("afterUse");
			};
		}
	}
		
	public IEnumerator afterUse() {
		//Destroyは次フレームの最初に入るので、
		//Destroy後の処理を1フレーム遅らせる
		yield return null;
		Align ();
	}

	public void Align() {
		for (int i = 0; i < GS.HAND_LIMIT; i++) {
			if (hands [i] == null) {
				Debug.Log ("hi");
				for (int j = i + 1; j < GS.HAND_LIMIT; j++) {
					if (hands [j] != null) {
						hands [j].transform.position = cardPos [i];
						hands [i] = hands [j];
						hands [j] = null;
						break;
					}
				}
			}
		}
	}
}
