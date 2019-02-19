using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class StatText : MonoBehaviour {

	string statName;
	int statValue;
	Text textBox;

	protected virtual void Awake () {
		textBox = gameObject.GetComponentInChildren<Text> ();
	}

	protected virtual void Start () {

	}

	void updateStatText () {
		textBox.text = statName + ": " + statValue;
	}

	public void updateStatName (string newName) {
		statName = newName;
		updateStatText ();
	}

	public void updateStatValue (int newValue) {
		statValue = newValue;
		updateStatText ();
	}

	public static void updateAllStatVals () {
		Stat1Text.instance.updateStatValue (GameController.Happiness);
		Stat2Text.instance.updateStatValue (GameController.Cleanliness);
		Stat3Text.instance.updateStatValue (GameController.Sanity);
	}
}
