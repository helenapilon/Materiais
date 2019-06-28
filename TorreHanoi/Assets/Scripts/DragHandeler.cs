using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;


public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public Vector3 startPosition;
	public static Transform startParent;
	public Transform[] discos;
	public int maior = 0;
	public static bool mover = false;
	int ndiscos = GetOp.nblocos;
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		Debug.Log ("N discos: " + ndiscos);
		mover = false;
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		discos = transform.parent.GetComponentsInChildren<Transform> ();
		maior = 0;
		for (int i = 0; i < discos.Length; i++) {
			int tags;
			bool teste = int.TryParse (discos [i].tag, out tags);
			if (teste != false)
			if (int.Parse (discos [i].tag) > maior)
				maior = int.Parse (discos [i].tag);
		}
		Debug.Log ("Maior: " + maior);
		if (int.Parse (transform.tag) == maior) {
			mover = true;
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if(mover == true)
			transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent == startParent) {
			transform.position = startPosition;
		}
		ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
		if (transform.parent.tag == "final" && transform.parent.childCount == ndiscos) {
			ativar.ativarModal ();
		}
	
	}
	#endregion
}