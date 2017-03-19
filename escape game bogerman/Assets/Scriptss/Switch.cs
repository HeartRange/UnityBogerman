using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	
	GameObject mainCamera;
	GameObject[] light;
	public Behaviour halo;
	public bool schakelaar;
	public GameObject LightSwitch;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		schakelaar = true;
		light = GameObject.FindGameObjectsWithTag ("Lighting");
		LightSwitch = GameObject.Find ("LightSwitch");
		LightSwitch.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		zetAan ();
	}
	void zetAan() {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 2)) {
				Switch1 p = hit.collider.GetComponent<Switch1>();
			if (p != null) {
				LightSwitch.SetActive (true);
				if (Input.GetKeyDown (KeyCode.E)) {
					if (schakelaar == true) {
						schakelaar = false;
						foreach (GameObject lights in light) {
							halo = (Behaviour)lights.GetComponent ("Halo");
							halo.enabled = !halo.enabled;
							lights.SetActive (schakelaar);
						}
					} else {
						schakelaar = true;
						foreach (GameObject lights in light) {
							halo = (Behaviour)lights.GetComponent ("Halo");
							halo.enabled = !halo.enabled;
							lights.SetActive (schakelaar);

						}
					}
				}
			} else {
				LightSwitch.SetActive (false);
			}
		}
	}
}
