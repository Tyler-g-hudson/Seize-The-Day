using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Log : MonoBehaviour {

	int textItems = 0;
	Text textBox;
	ContentSizeFitter sizeFitter;

	protected virtual void Awake () {
		textBox = gameObject.GetComponentInChildren<Text> ();
		sizeFitter = transform.parent.GetComponentInChildren<ContentSizeFitter> ();
	}

	protected virtual void Start () {
		refreshTextBox ();
		sizeFitter.SetLayoutVertical ();
		LogScrollBar.instance.updateLogScrollPosition (1f);
	}

	public virtual void updateTextBox (string input) {
		if (textItems > 0) {
			textBox.text += "\n";
		}

		textBox.text += input + "\n";
		textItems++;
		sizeFitter.SetLayoutVertical ();
	}

	public void refreshTextBox () {
		textBox.text = "";
		textItems = 0;
	}
}
