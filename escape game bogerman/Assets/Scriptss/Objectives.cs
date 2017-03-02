using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Objectives : MonoBehaviour {

	public bool obj1;
	public bool obj2;
	public bool obj3;
	public bool obj4;
	public bool obj5;
	public int obj1Int;

	// Use this for initialization
	void Start () {
		obj1 = false;
		obj2 = false;
		obj3 = false;
		obj4 = false;
		obj5 = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (obj1 == false && Time.time > 4) {
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 1;
			obj1 = true;
		} else if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) && obj1 == true && obj1Int < 6) {
			obj1Int += 1;
		} else if (obj1Int > 4 && obj1 == true && obj2 == false) {
			obj2 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 2;
		} else if (obj2 == true && GameObject.Find ("FirstPersonCharacter").GetComponent<PickupObject> ().carrying == true && obj3 == false) {
			obj3 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 3;
		} else if ((obj3 == true && obj4 == false) && GameObject.Find ("FirstPersonCharacter").GetComponent<PickupObject> ().throwed == true) {
			obj4 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 4;
		} else if (obj4 == true && obj5 == false && GameObject.Find ("FirstPersonCharacter").GetComponent<PlayMovieOnE> ().first == true) {
			obj5 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 5;
		}
	}
}
