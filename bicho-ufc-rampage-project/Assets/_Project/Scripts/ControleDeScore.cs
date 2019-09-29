using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDeScore : MonoBehaviour {

	public Text textoScore;
	public ControlsManager cAluno;

	private int score = 0;
	private int contadorDash = 0;

	// Singleton
	private static ControleDeScore instance = null;
	public static ControleDeScore GetInstance () {
		if (instance == null)
			instance = Instantiate <ControleDeScore> (instance);
		return instance;
	}

	void IncrementarScore (int valor) {
		score += valor;
		textoScore.text = "Score: " + score;
	}

	void IncrementaContDash () {
		contadorDash++;
		Debug.Log (contadorDash);
		if (contadorDash >= 4) {
			cAluno.SendMessage ("Dash");
			contadorDash = 0;
		}
	}

	public int GetScore (){
		return this.score;
	} 
}
