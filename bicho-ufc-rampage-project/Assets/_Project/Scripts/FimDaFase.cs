﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDaFase : MonoBehaviour {

	public CanvasRenderer panelFimDaFase;
	public ControleDaCamera controleDaCamera;
	public ControleDeTempo ControleDeTempo;

	void Awake () {
		panelFimDaFase.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			panelFimDaFase.gameObject.SetActive (true);
			col.gameObject.GetComponent <ControleDoPersonagem> ().SendMessage ("Parar");
			controleDaCamera.SendMessage ("Parar");
			ControleDeTempo.SendMessage ("Parar");
			float tempo = ControleDeTempo.GetInstance ().GetTempo ();
			int score = ControleDeScore.GetInstance ().GetScore ();
			SalvarRecuperarRanking.Salvar ("Gabs", tempo, score);
		}
	}
}
