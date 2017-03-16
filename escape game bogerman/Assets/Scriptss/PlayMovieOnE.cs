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
	GameObject Canvas;
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
		if(Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 5)) {
				Aanzetbaar p = hit.collider.GetComponent<Aanzetbaar>();
				if(p != null) {
					Aan = true;
					movie.Play();
					diaProjectorLight.enabled = !diaProjectorLight.enabled;
					audio1.Play();
					if (first == false) {
						GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().enabled = false;
						Camera2.GetComponent<Camera> ().enabled = true;
						Camera2.GetComponent<Animation> ().Play ();
						GameObject.Find ("PointLight").GetComponent<Animation> ().Play ();
						GameObject.Find ("Dak").GetComponent<AudioSource> ().volume = 0.5f;
						Canvas.SetActive (false);
						first = true;
					}
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
					GameObject.Find ("PointLight").GetComponent<Light> ().intensity = 1.37f;
					Canvas.SetActive(true);
					GameObject.Find ("Dak").GetComponent<AudioSource> ().volume = 1f;
					vidseen = true;


				}
			}
		}
	}
}