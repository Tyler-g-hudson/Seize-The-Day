using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stat2Text : StatText {
	
	public static Stat2Text instance;

	protected override void Awake () {
		base.Awake ();
		instance = this;
	}

	protected override void Start () {
		base.Start ();
		updateStatName ("Hygiene");
		updateStatValue (0);
	}
}
