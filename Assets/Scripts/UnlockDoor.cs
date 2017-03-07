using UnityEngine;
using System.Collections;


public class UnlockDoor : MonoBehaviour 
{
	public bool needsJohnKey;
	public bool needsCastleKey;
	public GameObject player;

	private Animator anim;
	private PlayerInventory playerInventory;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		playerInventory = player.GetComponent<PlayerInventory> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) 
		{
			if (needsJohnKey)
			{
				if (playerInventory.hasJohnKey) 
				{
					anim.SetBool ("OpenDoor", true);
				} 
			} 
			else if (needsCastleKey) 
			{
				if (playerInventory.hasCastleKey) 
				{
					anim.SetBool ("OpenDoor", true);	
				} 
			} 
			else 
			{
				anim.SetBool ("OpenDoor", true);
			}
		}
	}
}



