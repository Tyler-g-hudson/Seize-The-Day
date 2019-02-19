using UnityEngine;
using System.Collections;

public class BloodSmear : MonoBehaviour {

	public static bool bloodSplatter;
	public string updateText;

	// Use this for initialization
	void Awake () {
		if (bloodSplatter == false) {
			Destroy (gameObject);
		}
	}

	public void OnActionPerformed () {
		LogText.instance.updateTextBox (updateText);
		bloodSplatter = false;
		Destroy (gameObject);
	}
}
