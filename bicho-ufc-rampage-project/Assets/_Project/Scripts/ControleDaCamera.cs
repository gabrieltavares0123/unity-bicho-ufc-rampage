using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDaCamera : MonoBehaviour {
	
	public float velocidade;
	public Text textoScore;
	public Text textoTempo;
	public  CanvasRenderer panelComecar;
	public Transform aluno;

	private bool mover = false;
	private bool parar = false;

	void Awake () {
		textoTempo.enabled = false;
		//textoScore.enabled = false;
	}

	void Update () {
		//if (!mover && (Input.GetKeyUp ("a") || Input.GetButtonUp ("d") || Input.GetButtonUp ("space"))) {
		//	mover = true;
		//	textoScore.enabled = true;
		//	textoTempo.enabled = true;
		//	panelComecar.gameObject.SetActive (false);
		//}
	}

	void LateUpdate () {
		if (!parar && mover) {
			// Tenta centralizar o aluno caso ele vá muito para a frente
			if ((transform != null) && (aluno.position.x - 2f > transform.position.x)) {
				transform.position = Vector3.Lerp (transform.position, new Vector3 (aluno.position.x, transform.position.y, transform.position.z), .1f);
			} else {
				// Faz a câmera se mover constantemente para a direita depois que algum botão é apretado
				transform.Translate (velocidade * Time.deltaTime, 0, 0);
			}
		}
	}

	void Parar () {
		this.parar = true;
	}
}
