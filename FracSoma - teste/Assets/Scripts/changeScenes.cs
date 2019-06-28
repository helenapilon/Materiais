using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour {
	public static string nomeAnt;

	public void proxCena (string scenename)
	{
		cenaAnt ();
		SceneManager.LoadScene (scenename, LoadSceneMode.Single);

	}
	public static void proximaCena(string scenename)
	{
		cenaAnt();
		SceneManager.LoadScene(scenename, LoadSceneMode.Single);

	}
	public static void cenaAnt()
	{
		nomeAnt = SceneManager.GetActiveScene ().name;
		Debug.Log (SceneManager.GetActiveScene ().name);
	}
	public void acabar()
	{
		Application.Quit ();
	}
	void Update()
	{
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}
}