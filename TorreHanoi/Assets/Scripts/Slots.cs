using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler {
	[SerializeField] Transform slots;
	public static int movimentos = 0 ;
	public static int numeroblocos = GetOp.nblocos;
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
		int filhos = transform.childCount;
		//Debug.Log ("filhos: " + filhos + "parent: "+transform.name);
		bool teste = false;
		if (filhos > 0) {
			if (DragHandeler.mover == true) {
				if (int.Parse (transform.GetChild (filhos - 1).tag) < int.Parse (DragHandeler.itemBeingDragged.tag)) {
					DragHandeler.itemBeingDragged.transform.SetParent (transform);
					ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
					movimentos++;
				} else
					Debug.Log ("Não é possível mover esse objeto");
			}
		} else {
			if (DragHandeler.mover == true) {
				DragHandeler.itemBeingDragged.transform.SetParent (transform);
				ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
				movimentos++;
			}
		}
	}

	#endregion
}
