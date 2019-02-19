using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextDayButton : MonoBehaviour {
	
	public static NextDayButton instance;
	
	Text textBox;
	Button nextDayButton;

	public AudioClip sfxDoor;

	void Awake () {
		instance = this;
		textBox = gameObject.GetComponentInChildren<Text> ();
		nextDayButton = GetComponent<Button> ();
		sfxDoor = ((GameObject)Resources.Load ("door")).GetComponent<AudioSource> ().clip;
	}
	
	void Start () {
		nextDayButton.interactable = false;
		updateNextDayText ("To Work");
	}

	void updateNextDayText (string desiredText) {
		textBox.text = desiredText;
	}

	public void nextDayButtonPressed () {
		DayReportGroup.instance.activateDayReport ();
		DayReport.instance.refreshTextBox ();
		DayReport.instance.performDayReport ();
		nextDayButton.interactable = false;
		GameController.instance.StopMusic ();
		GameController.instance.PlaySFX (sfxDoor);
	}

	public void setInteractable (bool isInteractable) {
		nextDayButton.interactable = isInteractable;
	}
}
