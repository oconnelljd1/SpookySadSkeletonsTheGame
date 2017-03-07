using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameScreen: MonoBehaviour {

	private Animator canvasAnim;

	public RectTransform canvasPanel;

	//Use this for initialization
	void Start () {
		canvasAnim = canvasPanel.GetComponent<Animator>();
		canvasAnim.SetBool ("GP2P", false);
		canvasAnim.SetBool ("P2I", false);
		canvasAnim.SetBool ("P2GP", false);
		canvasAnim.SetBool ("I2P", false);
	}

	// Update is called once per frame
	public void gp2p() {

		//Debug.Log ("haha, it's not doing the stuff below!");

		canvasAnim.SetBool ("GP2P", true);
		canvasAnim.SetBool ("P2I", false);
		canvasAnim.SetBool ("P2GP", false);
		canvasAnim.SetBool ("I2P", false);
	}

	public void p2i() {

		canvasAnim.SetBool ("GP2P", false);
		canvasAnim.SetBool ("P2I", true);
				canvasAnim.SetBool ("P2GP", false);
		canvasAnim.SetBool ("I2P", false);
	}

	public void p2q() {
						canvasAnim.SetBool ("P2GP", true);
		canvasAnim.SetBool ("GP2P", false);
		canvasAnim.SetBool ("P2I", false);
		canvasAnim.SetBool ("I2P", false);
	}

	public void i2p() {

		canvasAnim.SetBool ("GP2P", false);
		canvasAnim.SetBool ("P2I", false);
		canvasAnim.SetBool ("P2GP", false);
		canvasAnim.SetBool ("I2P", true);
	}
}