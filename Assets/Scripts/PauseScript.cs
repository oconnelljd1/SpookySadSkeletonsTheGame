using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour 
{
	public RectTransform canvasPanel;

	private Animator canvasAnim;
	public bool isPaused;

	void Start()
	{
		//Time.timeScale = 0;
		isPaused = true;
		canvasAnim = canvasPanel.GetComponent<Animator> ();
	}

	public void Pause()
	{
		isPaused = true;
	}

	public void Unpause()
	{
		isPaused = false;
	}

	void GetInput()
	{
		if (Input.GetKeyDown (KeyCode.Tab)) {
			//Time.timeScale = 0;
			isPaused = true;
			canvasAnim.SetBool ("GameOver", false);
			canvasAnim.SetBool ("Options", false);
			canvasAnim.SetBool ("Instructions", false);
			canvasAnim.SetBool ("MainMenu", false);
			canvasAnim.SetBool ("GamePlay", false);
			canvasAnim.SetBool ("Paused", true);
			canvasAnim.SetBool ("PausedInstructions", false);
			canvasAnim.SetBool ("Quit", false);
		}
		else if (isPaused == true && (Input.GetKeyDown (KeyCode.Tab))) 
		{
			isPaused = false;
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
	void Update()
	{
		GetInput();
	}
}
