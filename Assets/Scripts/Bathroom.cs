using UnityEngine;
using System.Collections;

public class Bathroom : MonoBehaviour {

	static bool isClean = false;
	public static bool isChaos = false;
	Sprite bathroomImage;
	Sprite bathroomImageG;
	SpriteRenderer myRenderer;
	ObjectScript myObjectScript;

	void Awake () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myObjectScript = GetComponent<ObjectScript> ();
		PerformBathroomCheck ();
	}
	
	public void OnActionPerformed () {
		switch (Application.loadedLevelName) {
		case GameController.MODEST_PROPOSAL:
			isClean = true;
			break;
		default:
			break;
		}

		if (isClean)
			GameController.Cleanliness += 5;
		if (isChaos)
			GameController.Cleanliness += 5;
		PerformBathroomCheck ();
	}

	void PerformBathroomCheck () {
		if (isChaos) {
			bathroomImage = ((GameObject)Resources.Load ("BathroomBloody")).GetComponent<SpriteRenderer> ().sprite;
			bathroomImageG = ((GameObject)Resources.Load ("BathroomBloodyG")).GetComponent<SpriteRenderer> ().sprite;
			myObjectScript.nadirSprite = bathroomImage;
			myObjectScript.highlightSprite = bathroomImageG;
		} else if (isClean) {
			bathroomImage = ((GameObject)Resources.Load ("BathroomClean")).GetComponent<SpriteRenderer> ().sprite;
			bathroomImageG = ((GameObject)Resources.Load ("BathroomCleanG")).GetComponent<SpriteRenderer> ().sprite;
			myObjectScript.nadirSprite = bathroomImage;
			myObjectScript.highlightSprite = bathroomImageG;
		}
		myObjectScript.updateImage ();
	}
}
