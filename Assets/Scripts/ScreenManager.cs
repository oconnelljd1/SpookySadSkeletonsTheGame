using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenManager : MonoBehaviour {

	private Animator canvasAnim;

	//public RectTransform canvasPanel;

	// Use this for initialization
	void Start () {
	
		canvasAnim = gameObject.GetComponent<Animator>();

		canvasAnim.SetBool ("MainMenu", true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void mm2o(){
	
		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", true);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void mm2i(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", true);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void o2mm(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", true);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void i2gp(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", true);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void p2pi(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", true);
		canvasAnim.SetBool ("Quit", false);

	}

	public void p2mm(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", true);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void go2mm(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", true);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void go2gp(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", true);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void gp2go(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void gp2p(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", true);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void pi2p(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", true);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}

	public void mm2q(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", false);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", true);

	}

	public void p2gp(){

		canvasAnim.SetBool ("GameOver", false);
		canvasAnim.SetBool ("Options", false);
		canvasAnim.SetBool ("Instructions", false);
		canvasAnim.SetBool ("MainMenu", false);
		canvasAnim.SetBool ("GamePlay", true);
		canvasAnim.SetBool ("Paused", false);
		canvasAnim.SetBool ("PausedInstructions", false);
		canvasAnim.SetBool ("Quit", false);

	}
}
