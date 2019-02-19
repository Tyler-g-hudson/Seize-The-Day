using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {
	
	public static TimeText instance;
	
	Text textBox;

	void Awake () {
		textBox = gameObject.GetComponentInChildren<Text> ();
		textBox.text = "Minutes left: " + GameController.TimeMinutes;
	}
	
	void Start () {
		instance = this;
	}

	public void updateTimeText () {
		textBox.text = "Minutes left: " + GameController.TimeMinutes;
	}
}
