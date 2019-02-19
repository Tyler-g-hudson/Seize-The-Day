using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {

	public void OnActionPerformed () {
		BloodSmear.bloodSplatter = true;
	}
}
