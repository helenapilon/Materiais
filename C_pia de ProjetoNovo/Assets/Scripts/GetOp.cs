 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GetOp : MonoBehaviour, IHasChanged
{
	public Button ok;
	public static int op1;
	public int op2;
	public int tipo;
	public Dropdown tipoOp;
	Dropdown.OptionData mais, menos, selecione;
	public string valor1;
	public string valor2;
	public static int opcao;
	public static int valorOp;
	public static string operacao;



	// Use this for initialization
	void Start ()
	{
		
		mais = new Dropdown.OptionData ();
		menos = new Dropdown.OptionData ();
		selecione = new Dropdown.OptionData ();
		mais.text = "+";
		menos.text = "-";
		selecione.text = "Selecione: ";
		HasChanged ();
	}

	#region IHasChanged implementation

	public void HasChanged ()
	{
		tipoOp.ClearOptions ();
		tipoOp.RefreshShownValue();
		tipoOp.options.Add (selecione);
		tipoOp.options.Add (mais);
		tipoOp.options.Add (menos);
	}

	#endregion
	public void GetOp1(string v1)
	{
		valor1 = v1;
		Debug.Log (v1);
		op1 = int.Parse (valor1);
	}
	public void GetOp2(string v2)
	{
		valor2 = v2;
		Debug.Log (v2);
		op2 = int.Parse (valor2);
	}
	public void GetOption(int tp)
	{
		opcao = tp;
		Debug.Log (tp);

	}
	public void botaoOk(){
		if (opcao == 1) {
			Debug.Log (op1 + "+" + op2);
			valorOp = op1 + op2;
			Debug.Log (valorOp);
			operacao = op1 + "+" + op2;
		}
		else if(opcao == 2) {
			Debug.Log (op1 + "-" + op2);
			valorOp = op1 - op2;
			Debug.Log (valorOp);
			operacao = op1 + "-" + op2;
		}
	}

}