using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public Vector3 startPosition;
	public static Transform startParent;
	public static GameObject parentFinal;
	public float posy;
	public float posx;
	[SerializeField] Transform slotfinal;
	public string[] nomes = { "unidade", "dezena", "centena", "milhar", "dmilhar" };
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;

		if (startParent.tag == "inicio")
			parentFinal = GameObject.Find (transform.parent.name + "final");
		else if (startParent.tag == "final") {
			string nome = transform.parent.name.Remove (transform.parent.name.Length - 5);
			//Debug.Log ("-final: "+nome);
			parentFinal = GameObject.Find (nome);
		}
		posy = transform.position.y;


	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		posx = Input.mousePosition.x;
		Vector3 pos = new Vector3(Input.mousePosition.x, posy, Input.mousePosition.z);
		transform.SetPositionAndRotation(pos, transform.localRotation);
		//transform.position.x = posx;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
			itemBeingDragged = null;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
			transform.SetParent (parentFinal.transform);
			//transform.position = startPosition;
		for (int i = 0; i < 5; i++) {
			slotfinal = GameObject.Find (nomes [i]+"final").transform;
			if (slotfinal.childCount == 10) {
				for (int x = 0; x < 10; x++) {
					Transform bloco = slotfinal.GetChild (0);
					bloco.transform.SetParent (GameObject.Find (nomes [i]).transform);
				}
				Transform slot2 = GameObject.Find (nomes [i + 1] ).transform;
				Debug.Log ("Prox bloco: " + slot2.name);
				Transform proxbloco = slot2.GetChild(0);
				proxbloco.transform.SetParent (GameObject.Find (nomes [i + 1] + "final").transform);
				//lógica certa mas deve ser implementada em outro script, após a atualização de mudanca de parent
				if (changeScenes.nomeAnt == "operacao")
				{
					if (slotfinal.childCount == 0 && slot2.childCount == 10)
					{
						for (int x = 0; x < 10; x++)
						{
							Transform slot = GameObject.Find(nomes[i]).transform;
							Transform bloco = slot.GetChild(0);
							bloco.transform.SetParent(slotfinal);
						}
						Transform slotproxfinal = GameObject.Find(nomes[i + 1] + "final").transform;
						slot2.GetChild(0).SetParent(slotproxfinal);
					}
				}
			}
			
		}

		ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());

	}

	#endregion
}