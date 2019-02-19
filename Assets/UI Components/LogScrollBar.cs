using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogScrollBar : MonoBehaviour {

	public static LogScrollBar instance;

	Scrollbar logSB;

	void Awake () {
		instance = this;
		logSB = gameObject.GetComponentInChildren<Scrollbar> ();
	}

	public void updateLogScrollPosition (float desiredPos) {
		if (desiredPos >= 0 && desiredPos <= 1.01)
			logSB.value = desiredPos;
		else
			Debug.LogError ("updateScrollLogPosition error: desiredPos = " + desiredPos);
	}
}
