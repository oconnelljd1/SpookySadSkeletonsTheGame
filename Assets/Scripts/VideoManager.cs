using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class VideoManager : MonoBehaviour {

	private Animator canvasAnim;

	public RectTransform canvasPanel;
	//public GameObject canvasPanel;


	public MovieTexture movieIdle;
	public MovieTexture movieSelect;
	public MovieTexture moviePlay;

	// Use this for initialization
	void Start () {
		//canvasAnim = gameObject.GetComponent<Animator> ();
		canvasAnim = canvasPanel.GetComponent<Animator> ();
		GetComponent<RawImage> ().texture = movieIdle as MovieTexture;
		movieIdle.loop = true;
		movieIdle.Play ();
	}

	IEnumerator goIdle () {
		yield return new WaitForSeconds((1));
		GetComponent<RawImage> ().texture = movieIdle as MovieTexture;
		movieIdle.loop = true;
		movieIdle.Play ();
	}

	public void selectSomething(){
		//canvasPanel.GetComponent<RawImage> ().texture = movieSelect as MovieTexture;
		GetComponent<RawImage> ().texture = movieSelect as MovieTexture;
		movieSelect.Play ();
		movieSelect.loop = true;
		StartCoroutine (goIdle ());
	}

	// Update is called once per frame
	public void selectPlay () {
		GetComponent<RawImage> ().texture = moviePlay as MovieTexture;
		moviePlay.loop = false;
		moviePlay.Play ();
		StartCoroutine (startInstructions ());
	}

	IEnumerator startInstructions(){
		yield return new WaitForSeconds((1/2));
		//canvasAnim.SetBool ("MM2I", true);
	}
}
