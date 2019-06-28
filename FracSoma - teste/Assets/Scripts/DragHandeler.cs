using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public static int valor;
	public Vector3 startPosition;
	public static Transform startParent;
	public GameObject b1;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		//Debug.Log (transform.parent.tag);
		if (transform.parent.tag == "lixo") {
			
			if (startParent.tag == "1" || startParent.tag == "10" || startParent.tag == "100") {
				Transform blocoNovo = Instantiate (transform, startParent);
				blocoNovo.name = blocoNovo.name.Replace ("(Clone)", "");
				blocoNovo.name.Trim();
				//Instantiate (transform , startParent);
			}
			Destroy (itemBeingDragged);
		}
		if (startParent.childCount == int.Parse (startParent.name) - 1) {
			b1.transform.localScale = new Vector3(1, 1, 1);
			Transform blocoNovo = Instantiate (b1, startParent).transform;
			blocoNovo.name = blocoNovo.name.Replace ("(Clone)", "");
			blocoNovo.name.Trim();

		}
		int escala = Inventory.respMaior;
		Debug.Log ("Escala: " + escala);
		LayoutElement blc = transform.GetComponent<LayoutElement> ();
		blc.preferredWidth = (600/int.Parse(blc.name))/escala;
		Debug.Log ("Bloco: " + blc.name + "  Escala: " + escala);
		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent && transform.parent.tag!="lixo") {
				transform.position = startPosition;
			}

		ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());



	}

	#endregion
}