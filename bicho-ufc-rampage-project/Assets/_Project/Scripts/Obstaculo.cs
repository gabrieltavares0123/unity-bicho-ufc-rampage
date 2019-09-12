using UnityEngine;

public class Obstaculo : MonoBehaviour {

	/*void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			Vector2 pontoDeContato = col.contacts [0].normal;
			Debug.Log (pontoDeContato);
			Vector2 esquerda = new Vector2 (1.0f, 0.0f);
			if (pontoDeContato == esquerda) {
				ControleDoPersonagem cp = col.gameObject.GetComponent <ControleDoPersonagem> ();
				cp.SendMessage ("Bater");
			}
		}
	}*/

	void OnCollisionStay2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			Vector2 pontoDeContato = col.contacts [0].normal;
			Debug.Log (pontoDeContato);
			Vector2 esquerda = new Vector2 (1.0f, 0.0f);
			if (pontoDeContato == esquerda) {
				ControleDoPersonagem cp = col.gameObject.GetComponent <ControleDoPersonagem> ();
				cp.SendMessage ("Bater");
			}
		}
	}
}
