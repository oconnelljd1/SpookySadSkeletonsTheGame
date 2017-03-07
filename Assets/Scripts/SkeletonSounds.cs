using UnityEngine;
using System.Collections;

public class SkeletonSounds : MonoBehaviour {

	public AudioClip[] Sounds;
	public AudioSource aSource;



	// Use this for initialization
	void Start () {
		//turn objects in array into AudioClip's
		/*
		for(int n = 0; n < Sounds.Length; n++){
			Sounds[n] = AudioClip;
		}
		*/
		//start the random interval stuff's
		StartCoroutine (playSound ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator playSound(){
		//wait a random amount of time
		yield return new WaitForSeconds(Random.Range(20, 40));
		//set the clip to a random array entry
		aSource.clip = Sounds[(Random.Range (0, Sounds.Length))];
		aSource.Play ();
		//restart the process
		StartCoroutine (playSound ());
	}

}
