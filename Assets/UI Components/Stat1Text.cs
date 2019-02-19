using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stat1Text : StatText {
	
	public static Stat1Text instance;

	protected override void Awake () {
		base.Awake ();
		instance = this;
	}

	protected override void Start () {
		base.Start ();
		updateStatName ("Happiness");
		updateStatValue (0);
	}
}