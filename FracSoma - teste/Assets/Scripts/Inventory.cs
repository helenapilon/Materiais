using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, IHasChanged
{
	[SerializeField] Transform slots;
	[SerializeField] Text inventoryText;
	[SerializeField] Text opText;
	[SerializeField] Transform slotinicial;
	[SerializeField] Transform slotfinal;
	public static float valortotal;
	public static float resposta;
	public float largura;
	public static int respMaior, n;
	public string cenaAnt;

	// Use this for initialization
	void Start()
	{
		cenaAnt = changeScenes.nomeAnt;
		resposta = (float)GetOp.valorOp;
		Debug.Log("Resposta: " + resposta);

		if (resposta == 1 || resposta == 2 || resposta == 3)//ver se é numero inteiro
			respMaior = (int)resposta;
		else
			respMaior = (int)resposta + 1;
		largura = 600 / respMaior;
		largura = largura * resposta;
		LayoutElement painelinicial = slotinicial.GetComponent<LayoutElement>();
		LayoutElement painelfinal = slotfinal.GetComponent<LayoutElement>();
		painelinicial.preferredWidth = largura;
		painelfinal.preferredWidth = largura;

		if (cenaAnt == "operacao")
		{
			string denominador = ((int)GetOp.den1).ToString("D");
			Debug.Log("denominador: " + denominador);
			var bloco = GameObject.FindGameObjectWithTag(denominador);
			Debug.Log("Bloco: " + bloco.name);
			LayoutElement blc = bloco.GetComponent<LayoutElement>();
			blc.preferredWidth /= respMaior;
			if (GetOp.den1 == GetOp.den2)
			{
				n = (int)GetOp.num1 + (int)GetOp.num2;
				for (int x = 0; x < n; x++)
				{
					Instantiate(blc, slotinicial);
				}
			}
			else
			{
				n = (int)GetOp.num1;
				for (int x = 0; x < n; x++)
				{
					Instantiate(blc, slotinicial);
				}
				denominador = ((int)GetOp.den2).ToString("D");
				bloco = GameObject.FindGameObjectWithTag(denominador);
				blc = bloco.GetComponent<LayoutElement>();
				blc.preferredWidth /= respMaior;
				n = (int)GetOp.num2;
				for (int x = 0; x < n; x++)
				{
					Instantiate(blc, slotinicial);
				}
			}
		}
		else if (cenaAnt == "resultado")
		{
			string denominador = ((int)GetOp.den1).ToString("D");
			var bloco = GameObject.FindGameObjectWithTag(denominador);
			LayoutElement blc = bloco.GetComponent<LayoutElement>();
			blc.preferredWidth /= respMaior;
			n = (int)GetOp.num1;
			for (int x = 0; x < n; x++)
			{
				Instantiate(blc, slotinicial);
			}
		}
		valortotal = 0;
		HasChanged();
	}

	#region IHasChanged implementation
	public void HasChanged()
	{
		if (cenaAnt == "operacao")
		{
			opText.text = "OPERAÇÃO: " + GetOp.operacao.ToString();
			valortotal = 0;
			foreach (Transform slotTransform in slots)
			{
				for (int i = 0; i < slotTransform.childCount; i++)
				{
					valortotal += 1 / (float.Parse(slotTransform.GetChild(i).gameObject.tag));
					//valortotal = (float) System.Math.Round (valortotal, 2);
				}
				inventoryText.text = "VALOR TOTAL: " + valortotal.ToString();
				//Debug.Log ("Valor atual:  " + valortotal); 
				if (Mathf.Approximately(resposta, valortotal))
				{
					inventoryText.color = Color.green;
					ativar.ativarModal();
				}
				else
				{
					//Debug.Log ("Valor incorreto");
					inventoryText.color = Color.white;
				}
			}
		}
		else if (cenaAnt == "resultado")
		{
			opText.text = "RESULTADO: " + GetOp.operacao.ToString();
			valortotal = 0;
			foreach (Transform slotTransform in slots)
			{
				for (int i = 0; i < slotTransform.childCount; i++)
				{
					valortotal += 1 / (float.Parse(slotTransform.GetChild(i).gameObject.tag));
					//valortotal = (float) System.Math.Round (valortotal, 2);
				}
				inventoryText.text = "OPERAÇÃO: " + valortotal.ToString();
				//Debug.Log ("Valor atual:  " + valortotal); 
				if (Mathf.Approximately(resposta, valortotal))
				{
					inventoryText.color = Color.green;
					ativar.ativarModal();
				}
				else
				{
					//Debug.Log ("Valor incorreto");
					inventoryText.color = Color.white;
				}
			}
		}
	}
	#endregion
	public void voltar()
	{
		changeScenes.proximaCena(cenaAnt);
	}
}


namespace UnityEngine.EventSystems{
	public interface IHasChanged: IEventSystemHandler{
		void HasChanged ();
	}
}