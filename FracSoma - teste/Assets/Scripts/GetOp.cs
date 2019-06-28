using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GetOp : MonoBehaviour
{
	public Button ok;
	public string op1, op2;
	public static float num1 = -1.0f, num2 = -1.0f;
	public static float den1 = -1.0f, den2 = -1.0f;
	public int opcao;
	public static double valorOp;
	public static string operacao;
	public float div1, div2;
	string result2;
	public Transform WarningText1, WarningText2, WarningText3, WarningText4;

	// Use this for initialization
	void Start ()
	{
		//NADA TEM SENTIDO
		//NAO CONSEGUE VER QUE 1.16 É IGUAL A 1.17
		//E QUE DOIS TERCOS + UM MEIO É IGUAL A SETE SEXTOS QUE É IGUAL A UM INTEIRO E UM SEXTO
		//MAS APARENTEMENTE P PROGRAMA É TUDO DIFERENTE!!!
		//VERIFICAR SE OS DOIS NUMEROS ESTAO PREENCHIDOS

	}

	#region IHasChanged implementation

	#endregion
	public void GetNum1(string n1)
	{
		if (n1 == "")
			num1 = -1.0f;
		else
			num1 = float.Parse(n1);
		//Debug.Log ("Div1: " + div1);
		//verificar se o usuário informou primeiro o denominador
	}
	public void GetDen1(string d1)
	{
		if (d1 == "")
			den1 = -1.0f;
		else
			den1 = float.Parse(d1);
		//op1 = num1 + "/" + den1;
		//div1 = (num1 / den1);
		//Debug.Log ("Div1: " + div1);
	}
	public void GetNum2(string n2)
	{
		if (n2 == "")
			num2 = -1.0f;
		else
			num2 = float.Parse(n2);
		//Debug.Log ("Div2: " + div2);
	}
	public void GetDen2(string d2)
	{
		if (d2 == "")
			den2= -1.0f;
		else
			den2 = float.Parse(d2);
		//op2 = num2 + "/" + den2;
		//div2 = (num2 / den2);
		//Debug.Log ("Div2: " + div2);
	}
	public void botaoOk(){
		if (SceneManager.GetActiveScene ().name == "operacao") {
			if (num1 <= 0)
				WarningText1.gameObject.SetActive(true);
			else
				WarningText1.gameObject.SetActive(false);
			if (num2 <= 0)
				WarningText2.gameObject.SetActive(true);
			else
				WarningText2.gameObject.SetActive(false);
			if (den1 <= 0)
				WarningText3.gameObject.SetActive(true);
			else
				WarningText3.gameObject.SetActive(false);
			if (den2 <= 0)
				WarningText4.gameObject.SetActive(true);
			else
				WarningText4.gameObject.SetActive(false);
			if (num1 > 0 && num2 > 0 && den1 > 0 && den2 > 0)
			{
				op1 = num1 + "/" + den1;
				div1 = (num1 / den1);
				op2 = num2 + "/" + den2;
				div2 = (num2 / den2);
				valorOp = div1 + div2;
				Debug.Log("Valor total: " + valorOp);
				operacao = op1 + "+" + op2;
				Debug.Log("Resultado em fração: " + resultfracao());
				changeScenes.proximaCena("FracSoma");
			}
		}
		else if (SceneManager.GetActiveScene().name == "resultado")
		{
			if (num1 <= 0)
				WarningText1.gameObject.SetActive(true);
			else
				WarningText1.gameObject.SetActive(false);
			if (den1 <= 0)
				WarningText2.gameObject.SetActive(true);
			else
				WarningText2.gameObject.SetActive(false);
			if (num1 > 0 && den1 > 0)
			{
				op1 = num1 + "/" + den1;
				div1 = (num1 / den1);
				Debug.Log("Operação: " + op1);
				valorOp = div1;
				Debug.Log("Valor total: " + valorOp);
				operacao = op1;
				Debug.Log("Resultado em fração: " + resultfracao());
				changeScenes.proximaCena("FracSoma");
			}
		}
		
	}
	public float mmc(float d1, float d2)
	{
		float x = d1;
		float y = d2;
		float resto;
		do {
			resto = x % y;

			x = y;
			y = resto;
		} while(resto != 0);
		return (d1*d2)*x;
	}
	public string resultfracao(){
		float nresult = 0;
		float n1 = num1;
		float d1 = den1;
		if (SceneManager.GetActiveScene ().name == "operacao") {
			float n2 = num2;
			float d2 = den2;
			float dresult = mmc (den1, den2);
			if (den1 == den2) {	
				dresult = den1;
				nresult = num1 + num2;
			} else {
				nresult = (dresult / d1 * n1) + (dresult / d2 * n2);
			}
			if (nresult >= dresult && nresult % dresult == 0) {
				nresult = nresult / dresult;
				dresult = 1;
			}
			return nresult + "/" + dresult;
		} else {
			return num1 + "/" + den1;
		}
		return null;
	}
		
	void Update ()
	{
		
	}
}

