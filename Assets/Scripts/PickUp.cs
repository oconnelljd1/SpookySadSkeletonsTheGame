using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour {
	
	public GameObject player; // cal
	public GameObject johnKeyObj; // key to king john's room (needed so the object in scene is destoryed)
	public GameObject castleKeyObj; // key to king john (needed so the object in scene is destoryed)
	public GameObject KeyObj; // key to king john's room (needed so the object in scene is destoryed)
	private PlayerInventory playerInventory;
	public RectTransform canvasPanel;// for the canvas
	public RectTransform johnKey; // for the key on the canvas
	public RectTransform castleKey;

	void Awake()
	{
		playerInventory = player.GetComponent<PlayerInventory> ();
	}


	void OnTriggerEnter(Collider other)
	{
		//pick up the item
		if (other.tag == "JohnKey")
		{
			playerInventory.hasJohnKey = true; // add the key to the inventry
			Destroy (johnKeyObj); // kill the key
			johnKey.gameObject.SetActive (true); // add the key to the canvas
			Debug.Log("Got the Key to John's room");
		} 
		if (other.tag == "CastleKey") 
		{
			playerInventory.hasCastleKey = true; // add the key to the inventry
			Destroy (castleKeyObj); // kill the key
			castleKey.gameObject.SetActive(true); // add the key to the canvas
			Debug.Log ("has the Castle Key");
		}
		if (other.tag == "OtherKey") 
		{
			Destroy (KeyObj); // kill the key
			Debug.Log("Open the DOOR");
		}
			
	}

}
