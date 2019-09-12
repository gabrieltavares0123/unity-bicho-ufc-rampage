using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptDeInterface : MonoBehaviour {

	//----------------------------------------------
	// Métodos de eventos de interface
	// ---------------------------------------------
	public void Reiniciar () {
		SceneManager.LoadScene ("Fase1", LoadSceneMode.Single);
	}
}
