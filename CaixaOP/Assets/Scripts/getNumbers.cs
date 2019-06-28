using UnityEngine;
using System.Collections;

public class getNumbers : MonoBehaviour
{
	public static int v1, v2, sinal, nivel;
	public static float prox;
	// Use this for initialization
	void Start ()
	{
	}
	public void getNivel(int nNivel){
		nivel =  nNivel;
	}
	public static int gerarNumero1(){
		if (nivel == 2) {
			sinal = (int)Random.Range (1.0f, 3.0f);
			if (sinal == 1)
				v1 = (int)UnityEngine.Random.Range (1.0f, 30.0f);
			else if (sinal == 2)
				v1 = (int)UnityEngine.Random.Range (2.0f, 30.0f);
		} else {
			sinal = (int)Random.Range (1.0f, 3.0f);
			if (sinal == 1)
				v1 = (int)UnityEngine.Random.Range (1.0f, 15.0f);
			else if (sinal == 2)
				v1 = (int)UnityEngine.Random.Range (2.0f, 15.0f);
		}
		return v1;
	}
	public static int gerarNumero2(){
		if (nivel == 2) {
			if (sinal == 1) {
				prox = 31.0f - v1;
				v2 = (int)UnityEngine.Random.Range (1.0f, prox);
			} else if (sinal == 2)
				v2 = (int)UnityEngine.Random.Range (1.0f, v1);
		} else {
			if (sinal == 1) {
				prox = 16.0f - v1;
				v2 = (int)UnityEngine.Random.Range (1.0f, prox);
			} else if (sinal == 2)
				v2 = (int)UnityEngine.Random.Range (1.0f, v1);
		}
		return v2;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

