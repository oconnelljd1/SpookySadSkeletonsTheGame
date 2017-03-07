using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToVictory : MonoBehaviour {

	string loadWin;

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			SceneManager.LoadScene (loadWin);
		}
	}


}
