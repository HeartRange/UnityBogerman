using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayMovieOnE : MonoBehaviour {
	GameObject mainCamera;
	GameObject Camera2;
	bool Aan;
	public Renderer r;
	public MovieTexture movie;
	GameObject diaProjector;
	GameObject movieCube;
	public Projector diaProjectorLight;
	public AudioSource audio1;
	public GameObject FPSController;
	public bool first;
	public bool vidseen;
	public GameObject diaUI;
	GameObject Canvas;
	GameObject[] light;
	public Behaviour halo;
    public GameObject TextTest;
    public bool UITime;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
		diaProjector = GameObject.FindWithTag("diaProjector");
		movieCube = GameObject.FindWithTag("movieCube");
		r = movieCube.GetComponent<Renderer>();
		movie = (MovieTexture)r.material.mainTexture;
		diaProjectorLight = diaProjector.GetComponent<Projector>();
		diaProjectorLight.enabled = false;
		audio1 = movieCube.GetComponent<AudioSource>();
		Camera2 = GameObject.Find("Camera2");
		Camera2.GetComponent<Camera> ().enabled = false;
		first = false;
		Canvas = GameObject.Find ("Canvas");
		vidseen = false;
		diaUI = GameObject.Find ("diaUI");
		diaUI.SetActive (false);
		light = GameObject.FindGameObjectsWithTag ("Lighting");
        TextTest = GameObject.Find("TextTest");
        UITime = false;

	}

	// Update is called once per frame
	void Update () {
		if(Aan) {
			zetUit();
		} else {
			zetAan();
		}
	}


	void zetAan() {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 3)) {
				Aanzetbaar p = hit.collider.GetComponent<Aanzetbaar>();
				if(p != null) {
                UITime = true;
                TextTest.GetComponent<Animator>().SetBool("fadeStatus", true);
                diaUI.SetActive(true);
					if(Input.GetKeyDown (KeyCode.E)) {
					Aan = true;
					movie.Play();
					diaProjectorLight.enabled = !diaProjectorLight.enabled;
					audio1.Play();
					if (first == false) {
						GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = false;
						Camera2.GetComponent<Camera> ().enabled = true;
						Camera2.GetComponent<Animation> ().Play ();
						foreach (GameObject lights in light) {
							halo = (Behaviour)lights.GetComponent ("Halo");
							halo.enabled = !halo.enabled;
							lights.GetComponent<Animation> ().Play ();
						}
						GameObject.Find ("Dak").GetComponent<AudioSource> ().volume = 0.1f;
						Canvas.SetActive (false);
						first = true;
					}
				}
			}
			else{
                if (UITime == true)
                {
                    TextTest.GetComponent<Animator>().SetBool("fadeStatus", false);
                    diaUI.SetActive(false);
                    UITime = false;
                }
            }
        }
	}

	void zetUit() {
		if (Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera> ().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 5)) {
				Aanzetbaar p = hit.collider.GetComponent<Aanzetbaar> ();
				if (p != null) {
					Aan = false;
					movie.Pause ();
					diaProjectorLight.enabled = !diaProjectorLight.enabled;
					audio1.Pause ();
					GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
					Camera2.GetComponent<Camera> ().enabled = false;
					Canvas.SetActive(true);
					GameObject.Find ("Dak").GetComponent<AudioSource> ().volume = 0.5f;
					vidseen = true;
					foreach (GameObject lights in light) {
						halo = (Behaviour)lights.GetComponent ("Halo");
						halo.enabled = !halo.enabled;
						lights.GetComponent<Light>().intensity = 2.7f;

					}
				}
			}
		}
	}
}