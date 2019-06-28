using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GetOp : MonoBehaviour, IHasChanged
{
	public Button ok;
	public int tipo;
	public Dropdown tipoOp;
	Dropdown.OptionData tres, quatro, cinco, seis, sete, selecione;
	public int opcao;
	public static int nblocos;
	[SerializeField] Text label;



	// Use this for initialization
	void Start ()
	{
		tres = new Dropdown.OptionData ();
		quatro = new Dropdown.OptionData ();
		cinco = new Dropdown.OptionData ();
		seis = new Dropdown.OptionData ();
		sete = new Dropdown.OptionData ();
		selecione = new Dropdown.OptionData ();
		tres.text = "3";
		quatro.text = "4";
		cinco.text = "5";
		seis.text = "6";
		sete.text = "7";
		selecione.text = "SELECIONE"; 
		HasChanged ();
	}

	#region IHasChanged implementation

	public void HasChanged ()
	{
		tipoOp.ClearOptions ();
		tipoOp.RefreshShownValue();
		tipoOp.options.Add (selecione);
		tipoOp.options.Add (tres);
		tipoOp.options.Add (quatro);
		tipoOp.options.Add (cinco);
		tipoOp.options.Add (seis);
		tipoOp.options.Add (sete); 

	}


	#endregion
	public void GetOption(int n)
	{
		opcao = n;
	}
	public void mudar(){
		label.text = tipoOp.options [opcao].text.ToString();

	}
	public void botaoOk(){
		nblocos = int.Parse(tipoOp.options [opcao].text.ToString());
		Slots.movimentos = 0;
		Debug.Log ("Nblocos: " + nblocos);
	}

	// Update is called once per frame
	void Update ()
	{
		
	}
}

