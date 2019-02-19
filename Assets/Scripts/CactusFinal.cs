using UnityEngine;
using System.Collections;

public class CactusFinal : MonoBehaviour {

	void Awake () {
		if (Cactus.isDead) {
			SpriteRenderer myRenderer = GetComponent<SpriteRenderer> ();
			Sprite mySprite = ((GameObject)Resources.Load ("CatwithWings")).GetComponent<SpriteRenderer> ().sprite;
			myRenderer.sprite = mySprite;
		}
	}

}
