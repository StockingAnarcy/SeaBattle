using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitsCounterControl : MonoBehaviour {

	Text hitsCounterText;
	public static int hitsCounter;

	// Use this for initialization
	void Start () {
		hitsCounter = 0;
		hitsCounterText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		hitsCounterText.text = "Hits: " + hitsCounter;
	}
}
