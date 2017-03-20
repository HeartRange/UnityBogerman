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
	public bool obj6;
	public bool obj7;
	public bool obj8;
	public bool obj9;
	public bool obj10;
	public int obj1Int;
	public float deltatime;
	// Use this for initialization
	void Start () {
		obj1 = false;
		obj2 = false;
		obj3 = false;
		obj4 = false;
		obj5 = false;
		obj6 = false;
		obj7 = false;
		obj8 = false;
		obj9 = false;
		obj10 = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (obj1 == false && Time.time > 3) {
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 1;
			obj1 = true;
		} else if ((Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.D)) && obj1 == true && obj1Int < 6) {
			obj1Int += 1;
		} else if (obj1Int > 4 && obj1 == true && obj2 == false) {
			obj2 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 2;
		} else if (obj2 == true && GameObject.Find ("FirstPersonCharacter").GetComponent<Pickup> ().carrying == true && obj3 == false) {
			obj3 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 3;
		} else if ((obj3 == true && obj4 == false) && GameObject.Find ("FirstPersonCharacter").GetComponent<Pickup> ().throwed == true) {
			obj4 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 4;
		} else if (obj4 == true && obj5 == false && GameObject.Find ("FirstPersonCharacter").GetComponent<PlayMovieOnE> ().first == true) {
			obj5 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 5;
		} else if (obj5 == true && obj6 == false && GameObject.Find ("FirstPersonCharacter").GetComponent<someGlobals> ().gotkey == true) {
			obj6 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 6;
		} else if (obj6 == true && obj7 == false && GameObject.Find ("MyTrigger").GetComponent<Trigger> ().textline == true) {
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 7;
			deltatime += Time.deltaTime; 
		} else if (obj7 == true && obj8 == false && deltatime > 5f) {
			obj7 = true;
			obj8 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 8;
		} else if (obj8 == true && obj9 == false && GameObject.Find ("FirstPersonCharacter").GetComponent<someGlobals>().gotkey2 == true) {
			obj7 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 9;
		} else if (obj9 == true && obj10 == false && GameObject.Find ("MyTrigger").GetComponent<Trigger> ().startTime == true) {
			obj7 = true;
			GameObject.Find ("TextBoxManager").GetComponent<TextBoxManager> ().currentLine = 10;
		}


			
	}
}
