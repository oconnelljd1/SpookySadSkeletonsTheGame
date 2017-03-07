using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicLoop : MonoBehaviour {

	public AudioSource BGM;

	public Slider slider1;
	public Slider slider2;

	public AudioClip firstSong;
	public AudioClip secondSong;
	public AudioClip thirdSong;
	public AudioClip fourthSong;
	public AudioClip fifthSong;

	//public int currentSong = 0;

	/*
	private int FirstSongLength = firstSong.length;
	private int SecondSongLength = secondSong.length;
	private int ThirdSongLength = thirdSong.length;
	private int FourthSongLength = fourthSong.length;
	private int FifthSongLength = fifthSong.length;
	*/

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (gameObject);	

		//if (FindObjectsOfType<MusicLoop> ().Length > 1) {
		//	Destroy (gameObject);
		//	return;
		//}

		StartCoroutine (playFirstSong ());
	}


	// Update is called once per frame
	void Update () {
		if (!BGM.isPlaying) {
			if (BGM.name == "one") {
				StartCoroutine (playSecondSong ());
			} else if (BGM.name == "two") {
				StartCoroutine (playThirdSong ());
			} else if (BGM.name == "three") {
				StartCoroutine (playFirstSong ());
			} else if (BGM.name == "four") {
				StartCoroutine (playFirstSong ());
			} else if (BGM.name == "five") {
				StartCoroutine (playFirstSong ());
			}
		}
	}


	IEnumerator playFirstSong () {
		BGM.name = "one";
		BGM.Stop ();
		BGM.clip = firstSong;
		BGM.Play ();
		yield return null;
		//StartCoroutine (playSecondSong ());
	}

	IEnumerator playSecondSong (){
		BGM.name = "two";
		BGM.Stop ();
		BGM.clip = secondSong;
		BGM.Play ();
		yield return null;
		//StartCoroutine (playThirdSong ());
	}

	IEnumerator playThirdSong () {
		BGM.name = "three";
		BGM.Stop ();
		BGM.clip = thirdSong;
		BGM.Play ();
		yield return null;
		//StartCoroutine (playFirstSong ());
	}

	IEnumerator playFourthSong () {
		BGM.name = "four";
		BGM.Stop ();
		BGM.clip = fourthSong;
		BGM.Play ();
		yield return null;
		//StartCoroutine (playFirstSong ());
	}

	IEnumerator playFifthSong () {
		BGM.name = "five";
		BGM.Stop ();
		BGM.clip = fifthSong;
		BGM.Play ();
		yield return null;
		//StartCoroutine (playFirstSong ());
	}


	public void changeSong(){
		if (BGM.name == "one") {
			StartCoroutine (playSecondSong ());
		} else if (BGM.name == "two") {
			StartCoroutine (playThirdSong ());
		} else if (BGM.name == "three") {
			StartCoroutine (playFourthSong());
		} else if (BGM.name == "four") {
			StartCoroutine (playFifthSong());
		} else if (BGM.name == "five") {
			StartCoroutine (playFirstSong());
		}
	}

	public void changeSlider1(){
		BGM.volume = slider1.value;
		slider2.value = slider1.value;
	}
		
	public void changeSlider2(){
	
		BGM.volume = slider2.value;
		slider1.value = slider2.value;
	
	}

}
