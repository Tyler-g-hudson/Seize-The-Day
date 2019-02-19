using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseOverText : MonoBehaviour {
	
	public static MouseOverText instance;

	Text textBox;

	void Awake () {
		textBox = gameObject.GetComponentInChildren<Text> ();
	}
	
	void Start () {
		instance = this;
		setMouseOverText ("MouseOver");
		resetMouseOverText ();
	}

	public void setMouseOverText (string desiredText) {
		textBox.text = desiredText;
	}

	public void resetMouseOverText () {
		textBox.text = "";
	}

	public string readMouseOverText () {
		return textBox.text;
	}
}
