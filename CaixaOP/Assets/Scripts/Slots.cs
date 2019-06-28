using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler {
	[SerializeField] Transform slots;
	public static int contador=0;
	public GameObject item{
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}
	public void Start()
	{
		contador = 0;
	}
	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData) 
    { 
		Debug.Log ("Resultado: " + transform.tag + " Nome do Bloco: " + DragHandeler.itemBeingDragged.name);
		if (transform.tag == DragHandeler.itemBeingDragged.name && transform.childCount < 2) {
			DragHandeler.nextPosition = transform.position;
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
			contador++;
			if (contador == 15){
				contador = 0;
				ativar.ativarModal();
			}
		} 
		else {
			Debug.Log ("Resposta errada");
			DragHandeler.nextPosition = DragHandeler.startPosition;
			DragHandeler.itemBeingDragged.transform.position = transform.position;
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
			}
	}

	#endregion
}
