using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, IHasChanged {
	[SerializeField] Transform slots;
	[SerializeField] Text inventoryText;
	[SerializeField] Text opText;
	public int valortotal, x;
	public int resposta;
	public string nome;
	public string operacao;
	public int sub, subdm, subm, subc, subd, subu;
	public Transform unidade, dezena, centena, milhar, dmilhar;
	// Use this for initialization
	void Start () {
		resposta = GetOp2.valorOp;
		valortotal = 0;
		//nome = changeScenes.nomeAnt.ToString();
		if (changeScenes.nomeAnt.ToString() == "HomeScreen")
		{
			opText.enabled = false;
			resposta = -1;
		}
		else if (changeScenes.nomeAnt == "operacao") {
			if (GetOp2.opcao == 2) {//subtracao
				if (GetOp2.op1 > GetOp2.op2)
					sub = GetOp2.op1;
				else
					sub = GetOp2.op2;
				dmilhar = GameObject.Find ("dmilhar").transform;
				milhar = GameObject.Find ("milhar").transform;
				centena = GameObject.Find ("centena").transform;
				dezena = GameObject.Find ("dezena").transform;
				unidade = GameObject.Find ("unidade").transform;
				if (sub >= 10000) {
					subdm = (int) sub / 10000;
					sub = sub - subdm * 10000;
					for(x=0; x<subdm; x++)
						dmilhar.GetChild(0).SetParent(GameObject.Find ("dmilharfinal").transform);
				}
				if (sub >= 1000) {
					subm = (int) sub / 1000;
					sub = sub - subm * 1000;
					for(x=0; x<subm; x++)
						milhar.GetChild(0).SetParent(GameObject.Find ("milharfinal").transform);
				}
				if (sub >= 100) {
					subc = sub / 100;
					sub = sub - subc * 100;
					for(x=0; x<subc; x++)
						centena.GetChild(0).SetParent(GameObject.Find ("centenafinal").transform);
				}
				if (sub >= 10) {
					subd = sub / 10;
					sub = sub - subd * 10;
					for(x=0; x<subd; x++)
						dezena.GetChild(0).SetParent(GameObject.Find ("dezenafinal").transform);
				}
				subu = sub;
				for(x=0; x<subu; x++)
					unidade.GetChild(0).SetParent(GameObject.Find ("unidadefinal").transform);
				valortotal = 0;
				foreach (Transform slotTransform in slots) {
					//Debug.Log (slotTransform.name);
					for (int i = 0; i < slotTransform.childCount; i++) {
						valortotal += int.Parse (slotTransform.GetChild (i).gameObject.tag);
					}
				}

				inventoryText.text = "VALOR TOTAL: " + valortotal.ToString();

			}
				
		}
		HasChanged ();

	}
	#region IHasChanged implementation
	public void HasChanged ()
	{
		if (changeScenes.nomeAnt == "operacao")
		{
			operacao = GetOp2.operacao.ToString();
			opText.text = "OPERACAO: " + operacao;
			valortotal = 0;
			foreach (Transform slotTransform in slots)
			{
				//Debug.Log (slotTransform.name);
				for (int i = 0; i < slotTransform.childCount; i++)
				{
					valortotal += int.Parse(slotTransform.GetChild(i).gameObject.tag);
				}
			}

			inventoryText.text = "VALOR TOTAL: " + valortotal.ToString();
			if (resposta == valortotal)
			{
				inventoryText.color = Color.white;
				ativar.ativarModal();
			}
			else
			{
				Debug.Log("Valor incorreto");
				inventoryText.color = new Color32(0, 42, 60, 255);
			}
			if (GetOp2.opcao == 2)
			{
				dmilhar = GameObject.Find("dmilharfinal").transform;
				milhar = GameObject.Find("milharfinal").transform;
				centena = GameObject.Find("centenafinal").transform;
				dezena = GameObject.Find("dezenafinal").transform;
				unidade = GameObject.Find("unidadefinal").transform;
				if (dezena.childCount >= 1 && unidade.childCount == 0)
				{
					unidade = GameObject.Find("unidade").transform;
					for (x = 0; x < 10; x++)
						unidade.GetChild(0).SetParent(GameObject.Find("unidadefinal").transform);
					dezena.GetChild(0).SetParent(GameObject.Find("dezena").transform);
				}
				if (centena.childCount >= 1 && dezena.childCount == 0)
				{
					dezena = GameObject.Find("dezena").transform;
					for (x = 0; x < 10; x++)
						dezena.GetChild(0).SetParent(GameObject.Find("dezenafinal").transform);
					centena.GetChild(0).SetParent(GameObject.Find("centena").transform);
				}
				if (milhar.childCount >= 1 && centena.childCount == 0)
				{
					centena = GameObject.Find("centena").transform;
					for (x = 0; x < 10; x++)
						centena.GetChild(0).SetParent(GameObject.Find("centenafinal").transform);
					milhar.GetChild(0).SetParent(GameObject.Find("milhar").transform);
				}
				if (dmilhar.childCount >= 1 && milhar.childCount == 0)
				{
					milhar = GameObject.Find("milhar").transform;
					for (x = 0; x < 10; x++)
						milhar.GetChild(0).SetParent(GameObject.Find("milharfinal").transform);
					dmilhar.GetChild(0).SetParent(GameObject.Find("dmilhar").transform);
				}
			}
		}
		else if (changeScenes.nomeAnt == "HomeScreen")
		{
			opText.enabled = false;
			resposta = -1;
			valortotal = 0;
			foreach (Transform slotTransform in slots)
			{
				//Debug.Log (slotTransform.name);
				for (int i = 0; i < slotTransform.childCount; i++)
				{
					valortotal += int.Parse(slotTransform.GetChild(i).gameObject.tag);
				}
			}

			inventoryText.text = "VALOR TOTAL: " + valortotal.ToString();
			if (resposta == valortotal)
			{
				inventoryText.color = Color.white;
			}
			else
			{
				Debug.Log("Valor incorreto");
				inventoryText.color = new Color32(0, 42, 60, 255);
			}
		}
		//System.Text.StringBuilder builder = new System.Text.StringBuilder ();



	#endregion
	}
}
namespace UnityEngine.EventSystems{
	public interface IHasChanged: IEventSystemHandler{
		void HasChanged ();
	}
}