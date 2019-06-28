using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IDropHandler {
	public int nblocos;
	[SerializeField] Transform slots;
	public GameObject item{
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData) 
    { 
		Debug.Log ("parentFinal: " + transform.name + "Parent final tag: " + transform.tag);
	    if (transform.tag == "0" /*|| transform.childCount == 0*/) {
			float resp = Inventory.valortotal + (1/float.Parse(DragHandeler.itemBeingDragged.tag));
			if (resp-0.01f > Inventory.resposta){
				Debug.Log ("não é possivel soltar esse objeto");
				DragHandeler.itemBeingDragged.transform.position = transform.position;
				ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
			} else {
				DragHandeler.itemBeingDragged.transform.SetParent (transform);
				ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
			}
		} else if (transform.tag == "lixo" && DragHandeler.startParent.tag == "0") {
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
			Destroy (DragHandeler.itemBeingDragged);
		} else {
			DragHandeler.itemBeingDragged.transform.position = transform.position;
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
		}

	}

	#endregion
}
