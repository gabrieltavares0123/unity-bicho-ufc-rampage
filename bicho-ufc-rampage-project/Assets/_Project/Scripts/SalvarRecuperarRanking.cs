using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SalvarRecuperarRanking {

	/*
	 * Classe interna que representa um jogador
	*/
	[System.Serializable]
	private class Jogador{
		private int score;
		private string nome;
		private float tempo;

		public Jogador (string nome, float tempo, int score) {
			this.Nome = nome;
			this.tempo = tempo;
			this.score = score;
		}

		public float Tempo {
			get {
				return tempo;
			}
			set {
				tempo = value;
			}
		}

		public string Nome {
			get {
				return nome;
			}
			set {
				nome = value;
			}
		}

		public int Score {
			get {
				return score;
			}
			set {
				score = value;
			}
		}
	}

	static List<Jogador> ranking = new List<Jogador> (5);// Lista com os dados de todos os jogadores.

	public static void Salvar (string nome ,float tempo, int score) {
		Jogador novoJogador = new Jogador (nome, tempo, score);
		foreach (Jogador j in ranking) {
			if (ComparaJogadores (novoJogador, j)) {
				ranking[ranking.IndexOf (j)] = novoJogador;// Novo jogador fica na posição do antigo jogador
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Create (Application.persistentDataPath + "/jogosSalvos.gd");
				bf.Serialize (file, ranking);
				file.Close ();
				Debug.Log (novoJogador);
			}
		}
	}

	public static void Recuperar () {
		if (File.Exists (Application.persistentDataPath + "/jogosSalvos.gd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/jogosSalvos.gd", FileMode.Open);
			ranking = (List<Jogador>)bf.Deserialize (file);
			file.Close ();
		}
	}

	static bool ComparaJogadores (Jogador jogador1, Jogador jogador2) {
		if (jogador1.Score > jogador2.Score && jogador1.Tempo > jogador2.Tempo) {
			return true;
		}
		return false;
	}
}
