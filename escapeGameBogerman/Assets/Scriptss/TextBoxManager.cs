﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;



	// Use this for initialization
	void Start () {

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));

		}
	}
	void Update (){

		theText.text = textLines[currentLine];
	}
}