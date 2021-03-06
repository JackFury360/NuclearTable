﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Instructions")
			GetComponent<AudioSource> ().Stop ();

		if(SceneManager.GetActiveScene ().name == "MainMenu" && GetComponent<AudioSource> ().isPlaying == false)
			GetComponent<AudioSource> ().Play ();
	}
}
