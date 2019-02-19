using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayReportSB : MonoBehaviour {

	public static DayReportSB instance;

	Scrollbar reportSB;

	void Awake () {
		instance = this;
		reportSB = gameObject.GetComponentInChildren<Scrollbar> ();
	}

	public void updateReportScrollPosition (float desiredPos) {
		if (desiredPos >= 0 && desiredPos <= 1.01)
			reportSB.value = desiredPos;
		else
			Debug.LogError ("updateScrollLogPosition error: desiredPos = " + desiredPos);
	}
}
