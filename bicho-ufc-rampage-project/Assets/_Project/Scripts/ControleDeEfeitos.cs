using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeEfeitos : MonoBehaviour {

	public ParticleSystem particulasPegarItem;
	public int qtdParticulasPegarItem;
	private ParticleSystem.EmissionModule emParticulasPegarItem;

	// Singleton
	private static ControleDeEfeitos instance = null;
	public static ControleDeEfeitos GetInstance () {
		if (instance == null)
			instance = Instantiate <ControleDeEfeitos> (instance);
		return instance;
	}


	void Awake () {
		this.emParticulasPegarItem = particulasPegarItem.emission;
		this.emParticulasPegarItem.enabled = false;
	}

	void EmitirParticulasPegarItens (Vector2 pos) {
		transform.position = pos;
		particulasPegarItem.Emit (qtdParticulasPegarItem);
	}

}
