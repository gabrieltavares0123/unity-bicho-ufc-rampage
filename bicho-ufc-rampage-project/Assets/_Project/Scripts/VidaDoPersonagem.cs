using Magrathea.BichoUFCRampage.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDoPersonagem : MonoBehaviour {

	public CanvasRenderer panelMorreu;
	public ControleDaCamera controleDaCamera;
	public ControleDeTempo controleDeTempo;
	private ControlsManager cp;
	public Transform cam;

	void Awake () {
		panelMorreu.gameObject.SetActive (false);
		cp = GetComponent <ControlsManager> ();
	}

	void Morreu () {
		if (panelMorreu != null) {
			panelMorreu.gameObject.SetActive (true);
		}
	}

	void OnBecameInvisible () {
		// Só morre se sair do foco da câmera do lado esquerdo
		if ((cam != null) && (transform.position.x - 2f < cam.transform.position.x)) {
			// Para todos os scripts
			Morreu ();
			cp.SendMessage ("Parar");
			controleDaCamera.SendMessage ("Parar");
			controleDeTempo.SendMessage ("Parar");
		}
	}
}
