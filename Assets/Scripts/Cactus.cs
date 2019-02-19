using UnityEngine;
using System.Collections;

public class Cactus : MonoBehaviour {

	public static bool isDead = false;
	Sprite deadCactus;
	Sprite deadCactusG;
	SpriteRenderer myRenderer;
	ObjectScript myObjectScript;

	void Awake () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myObjectScript = GetComponent<ObjectScript> ();
		PerformPercivalCheck ();
	}

	void PerformPercivalCheck () {
		if (isDead) {
			deadCactus = ((GameObject)Resources.Load ("CactusSad")).GetComponent<SpriteRenderer> ().sprite;
			deadCactusG = ((GameObject)Resources.Load ("CactusSadG")).GetComponent<SpriteRenderer> ().sprite;
			myObjectScript.nadirSprite = deadCactus;
			myObjectScript.highlightSprite = deadCactusG;
			myObjectScript.setUsed (true);
		}
		myObjectScript.updateImage ();
	}
}
