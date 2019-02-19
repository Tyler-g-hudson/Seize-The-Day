using UnityEngine;
using System.Collections;

public class Poster : MonoBehaviour {

	static bool isTorn = false;
	Sprite posterImage;
	Sprite posterImageG;
	SpriteRenderer myRenderer;
	ObjectScript myObjectScript;

	void Awake () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myObjectScript = GetComponent<ObjectScript> ();
		PerformBathroomCheck ();
	}

	public void OnActionPerformed () {
		switch (Application.loadedLevelName) {
		case GameController.HELPER_DEMON:
			isTorn = true;
			break;
		default:
			break;
		}
		PerformBathroomCheck ();
	}

	void PerformBathroomCheck () {
		if (isTorn) {
			posterImage = ((GameObject)Resources.Load ("AnarchistPoster")).GetComponent<SpriteRenderer> ().sprite;
			posterImageG = ((GameObject)Resources.Load ("AnarchistPoster")).GetComponent<SpriteRenderer> ().sprite;
			if (myObjectScript != null) {
				myObjectScript.nadirSprite = posterImage;
				myObjectScript.highlightSprite = posterImageG;
				myObjectScript.updateImage ();
			} else {
				myRenderer.sprite = posterImage;
			}
		}
	}
}
