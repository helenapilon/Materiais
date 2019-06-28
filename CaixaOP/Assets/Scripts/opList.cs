using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
//using System.Linq;

public class opList : MonoBehaviour {
	public List<int> posSlot;
	[SerializeField] Transform SlotFinal;
	public Text texto;
	public string operacao;
	public int result, ran;
	public List<Transform> paineis;


	// Use this for initialization
	void Start () {
		Transform slot = GameObject.FindGameObjectWithTag ("0").transform;
		for (int i = 0; i < 15; i++) {
			do {
				ran = UnityEngine.Random.Range (0, 24);
			} while(slot.GetChild (ran).tag != "Untagged");
			Transform painel = slot.GetChild (ran);
			int v1 = getNumbers.gerarNumero1 ();
			int v2 = getNumbers.gerarNumero2 ();
			if (getNumbers.sinal == 1) {
				result = v1 + v2;
				operacao = v1 + "+" + v2;
			} else if (getNumbers.sinal == 2) {
				result = v1 - v2;
				operacao = v1 + "-" + v2;
			}			
			painel.GetComponentInChildren<Text> ().text = operacao;
			painel.GetComponent<Image> ().color = Color.white;
			painel.tag = result.ToString();
			//paineis.Add (painel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
