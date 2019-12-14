﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler {
	public GameObject b1;
	public GameObject b10;
	public GameObject b100;
	public GameObject slot1;
	public GameObject slot10;
	public GameObject slot100;
	public int nblocos1, nblocos10;
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
		if (transform.tag == "0" || transform.childCount == 0) {
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
		} else if (transform.tag == "lixo") {
			DragHandeler.itemBeingDragged.transform.SetParent (transform);
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
			Destroy (DragHandeler.itemBeingDragged);
		} else {
			DragHandeler.itemBeingDragged.transform.position = transform.position;
			ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
		}
		var blocos1 = GameObject.FindGameObjectsWithTag ("1");
		var blocos10 = GameObject.FindGameObjectsWithTag ("10");
		if (blocos1.Length > 10) {
			nblocos1 = 0;
			for (var j = 0; j <= 10; j++) {
				if (blocos1 [j].transform.parent.tag == "0") {
					nblocos1 = nblocos1 + 1;
					if (nblocos1 == 10) {
						for (var i = 0; i <= 10; i++) {
							if (blocos1 [i].transform.parent.tag == "0") {
								Destroy (blocos1 [i]);
							}
						}
						Instantiate (b10, transform);
						Instantiate(b1, DragHandeler.startParent);
					}
				}
			}
		}
		else if(blocos10.Length > 10) {
			nblocos10 = 0;
			for(var j=0; j<=10; j++) 
			{
				if(blocos10[j].transform.parent.tag == "0") {
					nblocos10 = nblocos10 + 1;
					if(nblocos10 == 10){
						for (var i = 0; i <= 10; i++) {
							if (blocos10 [i].transform.parent.tag == "0") {
								Destroy (blocos10 [i]);
							}
						}
						Instantiate (b100, transform);
						Instantiate (b10, DragHandeler.startParent);
					}
				}
			}
		}
	}

	#endregion
}
