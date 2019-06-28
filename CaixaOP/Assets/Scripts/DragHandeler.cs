using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public static Vector3 startPosition, nextPosition;
	public static Transform startParent;
	public static GameObject parentFinal;
	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
		//Debug.Log ("Atual: " + itemBeingDragged.transform.name);

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if(nextPosition != startPosition)
		{
			Transform blocoNovo = Instantiate (transform, startParent);
			blocoNovo.position = startPosition;
			blocoNovo.name = blocoNovo.name.Replace ("(Clone)", "");
			blocoNovo.name.Trim();
		}
		itemBeingDragged.transform.position = nextPosition;
		ExecuteEvents.ExecuteHierarchy < IHasChanged> (gameObject, null, (x, y) => x.HasChanged ());
		itemBeingDragged = null;

	}

	#endregion
}