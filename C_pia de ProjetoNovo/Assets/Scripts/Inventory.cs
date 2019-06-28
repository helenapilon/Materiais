using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, IHasChanged {
	[SerializeField] static Transform slots;
	[SerializeField] static Text inventoryText;
	[SerializeField] static Text opText;
	public static int resposta;
	public int x, nb10 = 0, nb100 = 0, nb1=0,  i, y;
	public string nome;
	public Transform slotfinal;
	public GameObject b1;
	public GameObject b10;
	public GameObject b100;
	public int sub;

	// Use this for initialization
	void Start () {
		opText = GameObject.Find("OP").GetComponent<Text> ();
		inventoryText = GameObject.Find ("VTotal").GetComponent<Text> ();
		slots = GameObject.Find ("PanelFinal").transform;
		resposta = GetOp2.valorOp;
		if (changeScenes.nomeAnt.ToString () == "HomeScreen") {
			opText.enabled=false;
			resposta = -1;
		}			
		else if (changeScenes.nomeAnt == "op2") {
			if (GetOp2.opcao == 2) {
				slotfinal = GameObject.Find ("SlotFinal").transform;
				if (GetOp2.op1 > GetOp2.op2)
					sub = GetOp2.op1;
				else
					sub = GetOp2.op2;
				int subc, subd, subu;
				if (sub >= 100) {
					subc = (int)sub / 100;
					sub = sub - subc * 100;
					for (x = 0; x < subc; x++)
						Instantiate (b100, slotfinal);
				}
				if (sub >= 10) {
					subd = (int)sub / 10;
					sub = sub - subd * 10;
					for (x = 0; x < subd; x++)
						Instantiate (b10, slotfinal);
				}
				if (sub >= 1) {
					subu = sub;
					sub = sub - subu;
					for (x = 0; x < subu; x++)
						Instantiate (b1, slotfinal);
				}

			}
		}
		HasChanged ();
	}

	#region IHasChanged implementation
	public void HasChanged ()
	{
		if (changeScenes.nomeAnt == "op2") {
			opText.text = "OPERAÇÃO: " + GetOp2.operacao.ToString();
			if (GetOp2.opcao == 2) {
				slotfinal = GameObject.Find ("SlotFinal").transform;
				nb1 = 0;
				nb10 = 0;
				nb100 = 0;
				foreach (Transform bloquinho in slotfinal) {
					if (bloquinho.tag == "10") {
						nb10++;
						i = slotfinal.GetSiblingIndex ();
					}
					else if (bloquinho.tag == "100")
					{
						nb100++;
						y = slotfinal.GetSiblingIndex();
					}
					else if (bloquinho.tag=="1")
						nb1++;
				}
				if (nb100 >= 1 && nb10 == 0)
				{
					Transform bDestruir100 = slotfinal.Find("b100(Clone)");
					DestroyImmediate(bDestruir100.gameObject);
					for (x = 0; x < 10; x++)
						Instantiate(b10, slotfinal);
				}
				if (nb10 >= 1 && nb1==0) {
					Transform bDestruir10 = slotfinal.Find("b10(Clone)");
					DestroyImmediate (bDestruir10.gameObject);
					for (x = 0; x < 10; x++)
						Instantiate (b1, slotfinal);
				}
				
			}	
		}
		AtualizarValor();
		#endregion
	}

	public static void AtualizarValor(){
		int valortotal = 0;
		foreach (Transform slotTransform in slots) {
			for (int i = 0; i < slotTransform.childCount; i++) 
				valortotal += int.Parse(slotTransform.GetChild(i).gameObject.tag);
		}

		Debug.Log ("Valor no slot: " + valortotal);
		inventoryText.text = "VALOR TOTAL: " + valortotal.ToString();
		if(resposta == valortotal){
			inventoryText.color = Color.green;
			ativar.ativarModal ();
		} 
		else{
			Debug.Log ("Valor incorreto");
			inventoryText.color = Color.white;
		}
	}
}

namespace UnityEngine.EventSystems{
	public interface IHasChanged: IEventSystemHandler{
		void HasChanged ();
	}
}