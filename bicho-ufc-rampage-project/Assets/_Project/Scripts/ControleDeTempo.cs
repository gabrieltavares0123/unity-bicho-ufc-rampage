using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDeTempo : MonoBehaviour {

	public Text textoTempo;

	private float tempo = 0;
	private bool contar = false;
	private bool parar = false;

	// Singleton
	private static ControleDeTempo instance = null;
	public static ControleDeTempo GetInstance () {
		if (instance == null)
			instance = Instantiate <ControleDeTempo> (instance);
		return instance;
	}

	void Update () {
		if (!this.contar && (Input.GetKeyUp ("a") || Input.GetButtonUp ("d") || Input.GetButtonUp ("space"))) {
			contar = true;
		} 
		if (!this.parar && this.contar) {
			ContarTempo ();
		}
	}

	void ContarTempo () {
		this.tempo += Time.deltaTime;
		textoTempo.text = "Tempo - " + this.tempo.ToString ("F3");
	}

	void Parar () {
		this.parar = true;
	}

	public float GetTempo () {
		return this.tempo;
	}
}
