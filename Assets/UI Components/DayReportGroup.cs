using UnityEngine;
using System.Collections;

public class DayReportGroup : MonoBehaviour {

	public static DayReportGroup instance;

	CanvasGroup dayReportGroup;

	void Awake () {
		instance = this;
		dayReportGroup = GetComponent<CanvasGroup> ();
	}

	void Start () {
		activateDayReport ();
	}

	public void deactivateDayReport () {
		dayReportGroup.interactable = false;
		dayReportGroup.blocksRaycasts = false;
		dayReportGroup.alpha = 0;
	}

	public void activateDayReport () {
		dayReportGroup.interactable = true;
		dayReportGroup.blocksRaycasts = true;
		dayReportGroup.alpha = 1;
	}
}
