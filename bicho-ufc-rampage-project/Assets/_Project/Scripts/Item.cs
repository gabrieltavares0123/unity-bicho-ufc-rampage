using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public ControleDeScore controleDeScore;
	public ControleDeEfeitos controleDeEfeitos;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			controleDeScore.SendMessage("IncrementarScore", 100);
			// Não funciona passando apenas transform.position
			Vector2 pos = transform.position;
			controleDeEfeitos.SendMessage ("EmitirParticulasPegarItens", pos);
			gameObject.SetActive (false);
			controleDeScore.SendMessage ("IncrementaContDash");
		}
	}
}
