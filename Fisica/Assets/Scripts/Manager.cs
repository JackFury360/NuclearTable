﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public string numpad;
    public int tableDoorOpen;
    public GameObject button;
	public GameObject[] buttonsWrong;
    public bool[] desafio;
    public GameObject[] parts;

    public bool restart;
    public float timer;

    public float lastTimer;

    public bool down;
    public bool canDown;

	public int errors;

	public GameObject[] meters;
	public PressureMeter[] meters2;
	public GameObject Led;

	public Text panelTxt;

	public Texture2D cursor;
	public Texture2D cursor2;
	public Vector2 cursorHotspot;

	public int fix;
	public Text fixTheCellTxt;
	public GameObject[] canvas;
	public bool controle;

	public GameObject gif;
	public float gifTimer;

	public GameObject[] menu;

    public GameObject atomicButton;
    public GameObject winTxt;

	public GameObject genesisTxt;

    public GameObject[] destruction;

    public float delayTimer;

    public GameObject menuBT;

    public GameObject canvasBG;
    // Use this for initialization
    void Start () {
        winTxt.SetActive(false);

        atomicButton.SetActive(false);

		gif.SetActive (false);

        canDown = true;

		foreach (GameObject go in meters)
			go.SetActive(false);

		cursorHotspot = new Vector2 (cursor.width / 2, cursor.height / 2);
		Cursor.SetCursor (cursor, cursorHotspot, CursorMode.Auto);

		foreach (GameObject go in menu)
			go.SetActive (false);

        foreach (GameObject go in destruction)
            go.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			Cursor.SetCursor (cursor2, cursorHotspot, CursorMode.Auto);
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			Cursor.SetCursor (cursor, cursorHotspot, CursorMode.Auto);
		}


        if(restart)
        {
            timer += Time.deltaTime;

            if(timer >= 0.5f)
            {
                restart = false;
                timer = 0;
            }
        }

		if (errors == 1) 
		{
			panelTxt.text = "Reator 1:  Esquentando\nReator 2:  Estável\nReator 3:  Estável";
		}

		else if (errors == 2) 
		{
			panelTxt.text = "Reator 1:  Perigo\nReator 2:  Estável\nReator 3:  Estável";
		}

		else if (errors == 3) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Estável\nReator 3:  Estável";
		}

		else if (errors == 4) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Esquentando\nReator 3:  Estável";
		}

		else if (errors == 5) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Perigo\nReator 3:  Estável";
		}

		else if (errors == 6) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Superaquecido\nReator 3:  Estável";
		}

		else if (errors == 7) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Superaquecido\nReator 3:  Esquentando";
		}

		else if (errors == 8) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Superaquecido\nReator 3:  Perigo";
		}

		else if (errors == 9 || Led.GetComponent<Animator>().enabled == true) 
		{
			panelTxt.text = "Reator 1:  Superaquecido\nReator 2:  Superaquecido\nReator 3:  Superaquecido";
			Led.GetComponent<Animator> ().enabled = true;
			meters [0].SetActive (true);
			meters [1].SetActive (true);
			meters [2].SetActive (true);
		}

		if (Led.GetComponent<Animator> ().enabled == true) 
		{
			foreach (GameObject go in canvas) {
				go.SetActive (false);
			}
			gif.SetActive (true);
			gifTimer += Time.deltaTime;
			genesisTxt.SetActive (false);
            menuBT.SetActive(false);
            canvasBG.SetActive(false);

            if (gifTimer >= 2.5 && gifTimer < 4.2f)
            {
                destruction[0].SetActive(true);

                delayTimer += Time.deltaTime;

                if (delayTimer > 0.15f)
                {
                    destruction[1].SetActive(!destruction[1].activeSelf);
                    delayTimer = 0;
                }
            }

            if (gifTimer >= 2)
                foreach (GameObject go in menu)
                go.SetActive(true);

            if (gifTimer > 2.6f && gifTimer < 2.7f)
                Camera.main.GetComponent<CameraShake>().shakeDuration = 1.3f;

            if (gifTimer >= 4.2) {
                destruction[1].SetActive(true);
			}
		}
			
		if (errors >= 3) 
		{
			meters [0].SetActive (true);
		}

		if (errors >= 6) 
		{
			meters [1].SetActive (true);
		}

		if (errors >= 9 && GameObject.Find("Manager").GetComponent<Manager>().atomicButton.activeSelf == false) 
		{
			meters [2].SetActive (true);
			Led.GetComponent<Animator>().enabled = true;
		}

        for(int i = 0; i < desafio.Length; i++)
        {
            if (desafio[i] == true)
                parts[i].SetActive(true);

            else
                parts[i].SetActive(false);
        }

		if(numpad == "2003" && tableDoorOpen == 0)
        {
            tableDoorOpen = 1;
        }

		foreach (GameObject go in buttonsWrong) 
		{
			if (go.GetComponent<Animator> ().GetBool ("Pressed") == true && controle == true) {
				errors += 1;

				if (errors <= 3)
					meters2[0].active = true;
				else if (errors > 3 && errors <= 6)
					meters2[1].active = true;
				else if (errors > 6 && errors <= 9)
					meters2[2].active = true;

				controle = false;
			}
		}

		if (button.GetComponent<Animator>().GetBool("Pressed") == true && fix < 4  && controle == true)
		{
			errors += 1;

            if (errors <= 3)
                meters2[0].active = true;
            else if (errors > 3 && errors <= 6)
                meters2[1].active = true;
            else if (errors > 6 && errors <= 9)
                meters2[2].active = true;

            controle = false;
		}

		if (button.GetComponent<Animator>().GetBool("Pressed") == true && tableDoorOpen == 2 && canDown == true && fix >= 4)
        {
            down = true;
        }

		if(fix < 4)
			fixTheCellTxt.text = "Conserte a Célula\nde Urânio";

		else
			fixTheCellTxt.text = "Aperte o botão correto\npara guardar a célula";

        if(desafio[0] == true && desafio[1] == true && desafio[2] == true && restart == true)
        {
            atomicButton.SetActive(true);
        }

        if(atomicButton.GetComponent<Animator>().GetBool("Pressed") == true)
        {
            desafio[3] = true;
        }

        if(desafio[3] == true)
        {
            lastTimer += Time.deltaTime;

            if (lastTimer >= 0.5f)
            {
                winTxt.SetActive(true);
            }
        }
    }
}
