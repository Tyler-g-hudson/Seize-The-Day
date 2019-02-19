using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LogText : Log {
	
	public static LogText instance;

	protected override void Awake () {
		base.Awake ();
		instance = this;
	}

	public override void updateTextBox (string input) {
		base.updateTextBox (input);
		LogScrollBar.instance.updateLogScrollPosition (0f);
	}
}