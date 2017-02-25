using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaProjector : MonoBehaviour {
	GameObject mainCamera;
	bool Aan;
	public Projector diaProjectorLight;
	GameObject diaProjector;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		diaProjector = GameObject.FindWithTag("diaProjector");
		diaProjectorLight = diaProjector.GetComponent<Projector>();

	}

	// Update is called once per frame
	void Update () {
		if(Aan) {
			checkUit();
		} else {
			zetAan();
		}
	}
		

	void zetAan() {
		if(Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 5)) {
				Aanzetbaar p = hit.collider.GetComponent<Aanzetbaar>();
				if(p != null) {
					Aan = true;
					diaProjectorLight.enabled = !diaProjectorLight.enabled;
				}
			}
		}
	}

	void checkUit() {
		if(Input.GetKeyDown (KeyCode.E)) {
			zetUit();
		}
	}
	void zetUit() {
		Aan = false;
		diaProjectorLight.enabled = !diaProjectorLight.enabled;
	}
}