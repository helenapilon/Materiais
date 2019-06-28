using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public string v1;
	public string v2;
	public int tp;
	public void GetOp1(string v1)
	{
		Debug.Log (v1);
	}
	public void GetOp2(string v2)
	{
		Debug.Log (v2);
	}
	public void GetOption(int tp)
	{
		Debug.Log (tp);
	}

}
