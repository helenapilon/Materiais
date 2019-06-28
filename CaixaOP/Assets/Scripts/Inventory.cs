using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IHasChanged {

	// Use this for initialization
	void Start () {
	}

	#region IHasChanged implementation
	public void HasChanged ()
	{

	}
	#endregion
}


namespace UnityEngine.EventSystems{
	public interface IHasChanged: IEventSystemHandler{
		void HasChanged ();
	}
}