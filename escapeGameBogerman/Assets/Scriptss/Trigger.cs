using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Trigger : MonoBehaviour {
	
	public GameObject FirstPersonCharacter;
	public GameObject FPSController;
	public AudioClip Au;
	public AudioClip RipMuziek;
	public AudioSource Beerman;
	public bool startTime;
	public float timer;
	public float totaltime;
	public float secondtime;
	public float halftime;
	public Animator anim;
	public GameObject teleporter;
	public bool startTime2;
	public bool startTime3;
	public bool textline;


	void OnTriggerEnter(Collider other)
	{
		anim = GameObject.Find ("BearGryllz").GetComponent<Animator> ();
		Beerman = GameObject.Find ("BearGryllz").GetComponent<AudioSource> ();
		startTime2 = true;
		startTime3 = true;
		textline = false;

		if (other.gameObject.tag == "Player") {
			anim.SetBool ("CheckDoor", true);
            FirstPersonCharacter.GetComponent<Fading>().fadespeed = 0.05f;
            FirstPersonCharacter.GetComponent<Fading>().BeginFade(1);
			AudioSource.PlayClipAtPoint (RipMuziek, transform.position, 0.5f);
			GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = false;
			startTime = true;
			totaltime = 4.5f;
			halftime = 6.0f;
			secondtime = 6.1f;
			GameObject.Find ("Dak").GetComponent<AudioSource> ().volume = 0.1f;
			Beerman.Play ();
		}
			
	}
	void Update()
	{
		if (startTime == true) {
			timer += Time.deltaTime;
			if (timer > totaltime && startTime2 == true && startTime3 == true) {
				FirstPersonCharacter.GetComponent<Fading> ().fadespeed = 0.1f;
				FirstPersonCharacter.GetComponent<Fading> ().BeginFade (-1);
				GameObject.Find ("Dak").GetComponent<AudioSource> ().volume = 0.1f;
				AudioSource.PlayClipAtPoint (Au, transform.position, 1f);
				startTime2 = false;
				startTime3 = false;
			}
			if (timer > halftime) {
				teleporter.SetActive (true);
			}
			if (timer > secondtime) {
				GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = true;
				startTime = false;
				textline = true;
			}
		}
	}
	void Start(){
		teleporter = GameObject.Find ("teleporter");
		teleporter.SetActive (false);

	}
}
