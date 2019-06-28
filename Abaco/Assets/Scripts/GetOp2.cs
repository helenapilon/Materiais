using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class GetOp2 : MonoBehaviour
{ 
	public Button ok;
	public static int op1 = -1;
	public static int op2 = -1;
	public int tipo;
	public string valor1;
	public string valor2;
	public static int opcao = 0;
	public static int valorOp;
	public static string operacao;
	public Transform WarningText1, WarningText2, WarningText3;



	// Use this for initialization
	void Start()
	{
		op1 = -1;
		op2 = -1;
		opcao = 0;
	}

	public void GetOp1(string v1)
	{
		if (v1 == "")
			valor1 = "-1";
		else
			valor1 = v1;
		//Debug.Log(v1);
		op1 = int.Parse(valor1);
	}
	public void GetOpe2(string v2)
	{
		if (v2 == "")
			valor2 = "-1";
		else
			valor2 = v2;
		//Debug.Log(v2);
		op2 = int.Parse(valor2);
	}
	public void GetOption(int ope)
	{
		opcao = ope;
		//Debug.Log(ope);

	}
	public void botaoOk()
	{
		
		if (opcao == 0)
			WarningText3.gameObject.SetActive(true);
		else
			WarningText3.gameObject.SetActive(false);
		if (op1 < 0)
			WarningText1.gameObject.SetActive(true);
		else
			WarningText1.gameObject.SetActive(false);
		if (op2 < 0)
			WarningText2.gameObject.SetActive(true);
		else
			WarningText2.gameObject.SetActive(false);
		if (op1 >= 0 && op2 >= 0 && opcao != 0)
		{
			if (opcao == 1)
			{
				//Debug.Log(op1 + "+" + op2);
				valorOp = op1 + op2;
				//Debug.Log(valorOp);
				operacao = op1 + "+" + op2;
			}
			else if (opcao == 2)
			{
				//Debug.Log(op1 + "-" + op2);
				if (op2 > op1)
					valorOp = op2 - op1;
				else
					valorOp = op1 - op2;
				//Debug.Log(valorOp);
				operacao = op1 + "-" + op2;
			}
			changeScenes.proximaCena("Abaco");
		}
	}

}