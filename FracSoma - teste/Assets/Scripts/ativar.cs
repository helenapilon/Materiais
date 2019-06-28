using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativar : MonoBehaviour {
	public GameObject mod;
	public static GameObject modal;
	// Use this for initialization
	void Start () {
		modal = mod;
		Debug.Log ("Modal: " + modal.transform.name);
	}

	public void desativar(){
		modal.SetActive (false);
		Debug.Log ("Modal desativado");
	}

	public static void ativarModal(){
		Debug.Log ("Modal ativado");
		modal.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
