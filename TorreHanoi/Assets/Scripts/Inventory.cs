using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour, IHasChanged {
	[SerializeField] Transform slots;
	[SerializeField] Text inventoryText;
	[SerializeField] Text nmin;
	public Transform d1, d2, d3, d4, d5, d6, d7;
	public int[] movmin = { 7, 15, 31, 63, 127};
	public Transform inicial;
	public string nome;
	public int numeroblocos;

	// Use this for initialization
	void Start () {
		inicial = GameObject.FindGameObjectWithTag ("inicio").transform;
		numeroblocos  = GetOp.nblocos;
		//valortotal = 0;
		nmin.text = "NÚMERO MÍNIMO DE MOVIMENTOS: " + (movmin[numeroblocos-3]).ToString();
		Instantiate (d1, inicial);
		Instantiate (d2, inicial);
		Instantiate (d3, inicial);
		if (numeroblocos == 4)
			Instantiate (d4, inicial);
		else if (numeroblocos == 5) {
			Instantiate (d4, inicial);
			Instantiate (d5, inicial);
		}
		else if (numeroblocos == 6) {
			Instantiate (d4, inicial);
			Instantiate (d5, inicial);
			Instantiate (d6, inicial);
		}
		else if (numeroblocos == 7) {
			Instantiate (d4, inicial);
			Instantiate (d5, inicial);
			Instantiate (d6, inicial);
			Instantiate (d7, inicial);
		}

		HasChanged ();
	}

	#region IHasChanged implementation
	public void HasChanged ()
	{
		//System.Text.StringBuilder builder = new System.Text.StringBuilder ();


		inventoryText.text = "MOVIMENTOS: " + Slots.movimentos.ToString ();
	}
	#endregion
}


namespace UnityEngine.EventSystems{
	public interface IHasChanged: IEventSystemHandler{
		void HasChanged ();
	}
}