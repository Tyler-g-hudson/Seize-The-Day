using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayText : MonoBehaviour {
	
	public static DayText instance;
	
	Text textBox;

	void Awake () {
		textBox = gameObject.GetComponentInChildren<Text> ();
	}
	
	void Start () {
		instance = this;
		updateDateText ();
	}

	public void updateDateText () {
		textBox.text = "Day: " + GameController.DayNum;
	}
}
