using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stat3Text : StatText {
	
	public static Stat3Text instance;

	protected override void Awake () {
		base.Awake ();
		instance = this;
	}

	protected override void Start () {
		base.Start ();
		updateStatName ("Lucidity");
		updateStatValue (0);
	}
}
