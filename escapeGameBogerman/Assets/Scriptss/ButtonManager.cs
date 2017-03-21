using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class ButtonManager : MonoBehaviour {
	GameObject options;
	public bool option;
    public Escape escape;
    public FirstPersonController fps;

	void Start()
	{
		options = GameObject.Find ("OptionsPanel");
		options.SetActive (false);
		option = true;
        escape = GameObject.Find("FirstPersonCharacter").GetComponent<Escape>();
        fps = GameObject.Find("FPSController").GetComponent<FirstPersonController>();

    }

	public void NewGameBtn(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	public void ExitGameBtn()
	{
		Application.Quit ();
	}

	public void OptionsBtn()
	{
		options.SetActive (option);
		option = !option;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void BackBtn()
    {
        escape.checkKey = false;
        escape.buttons.SetActive(false);
        options.SetActive(false);
        fps.enabled = true;
    }
    public void ApplyBtn()
    {
        options.SetActive(false);
    }
}
