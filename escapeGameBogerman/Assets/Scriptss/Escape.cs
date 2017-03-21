using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Escape : MonoBehaviour {

    public GameObject buttons;
    public GameObject optionsPanel;
    public bool checkKey;
	// Use this for initialization
	void Start () {

        buttons = GameObject.Find("Buttons");
        buttons.SetActive(false);
        optionsPanel = GameObject.Find("OptionsPanel");
        checkKey = false;
        		
	}
	
	// Update is called once per frame
	void Update () {

        CursorVisable();

        if (Input.GetKeyDown(KeyCode.Escape) && checkKey == false)
        {
            buttons.SetActive(true);
            checkKey = true;
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            checkKey = false;
            buttons.SetActive(false);
            optionsPanel.SetActive(false);
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        }
	}

    void CursorVisable()
    {
        if (checkKey == false)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
