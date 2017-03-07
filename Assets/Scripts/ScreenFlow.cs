using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlow: MonoBehaviour {

	private Animator canvasAnim;

	public RectTransform canvasPanel;

	//Use this for initialization
	void Start () 
	{
		canvasAnim = canvasPanel.GetComponent<Animator>();

		if (FindObjectsOfType<ScreenFlow> ().Length > 1) {
			Destroy (gameObject);
			return;
		}
		//DontDestroyOnLoad (canvasPanel);
	}
	
	// Update is called once per frame
	public void mm2o() 
	{

		//Debug.Log ("haha, it's not doing the stuff below!");

		canvasAnim.SetBool ("Iexit", false);
		canvasAnim.SetBool ("MM2I", false);
		canvasAnim.SetBool ("MM2O", true);
		canvasAnim.SetBool ("O2MM", false);
		canvasAnim.SetBool ("GO2MM", false);
		canvasAnim.SetBool ("MMexit", false);
	}

	public void o2mm() 
	{

		//Debug.Log ("haha, it's not doing the stuff below!");

		canvasAnim.SetBool ("Iexit", false);
		canvasAnim.SetBool ("MM2I", false);
		canvasAnim.SetBool ("MM2O", false);
		canvasAnim.SetBool ("O2MM", true);
		canvasAnim.SetBool ("MMexit", false);
		canvasAnim.SetBool ("GO2MM", false);
	}

	public void go2mm() 
	{

		//Debug.Log ("haha, it's not doing the stuff below!");

		canvasAnim.SetBool ("Iexit", false);
		canvasAnim.SetBool ("MM2I", false);
		canvasAnim.SetBool ("MM2O", false);
		canvasAnim.SetBool ("O2MM", false);
		canvasAnim.SetBool ("GO2MM", true);
		canvasAnim.SetBool ("gameover", false);
		canvasAnim.SetBool ("MMexit", false);
	}

	public void mm2i() 
	{

		canvasAnim.SetBool ("Iexit", false);
		canvasAnim.SetBool ("MM2I", true);
		canvasAnim.SetBool ("MM2O", false);
		canvasAnim.SetBool ("O2MM", false);
		canvasAnim.SetBool ("GO2MM", false);
		canvasAnim.SetBool ("MMexit", false);
	}

	public void iExit() 
	{

		canvasAnim.SetBool ("Iexit", true);
		canvasAnim.SetBool ("MM2I", false);
		canvasAnim.SetBool ("MM2O", false);
		canvasAnim.SetBool ("O2MM", false);
		canvasAnim.SetBool ("GO2MM", false);
		canvasAnim.SetBool ("MMexit", false);
	}

	public void mmExit()
	{
		canvasAnim.SetBool ("MMexit", true);
		canvasAnim.SetBool ("Iexit", true);
		canvasAnim.SetBool ("MM2I", false);
		canvasAnim.SetBool ("MM2O", false);
		canvasAnim.SetBool ("O2MM", false);
		canvasAnim.SetBool ("GO2MM", false);
	}




	//Canvas.SetBool ("enter", false);


}
