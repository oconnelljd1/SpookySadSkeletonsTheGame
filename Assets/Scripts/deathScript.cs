using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour 
{
	public RectTransform lives3;
	public RectTransform lives2;
	public RectTransform lives1;
	//public RectTransform canvasPanel;
	public Transform respawn;
	public RectTransform oldCanvas;
	public int lives = 3;

	private Animator canvasAnim;

	void Awake()
	{
		lives3.gameObject.SetActive(true);
		lives = 3;
		//oldCanvas = FindObjectOfType<UICanvas>;
		canvasAnim = oldCanvas.GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") 
		{
			transform.position = respawn.position;
			lives -= 1;
			if (lives == 2) 
			{
				lives3.gameObject.SetActive (false);
				lives2.gameObject.SetActive (true);
			}
			else if (lives == 1)
			{
				lives2.gameObject.SetActive (false);
				lives1.gameObject.SetActive (true);
			}
			else 
			{
				canvasAnim.SetBool ("GameOver", true);
				canvasAnim.SetBool ("Options", false);
				canvasAnim.SetBool ("Instructions", false);
				canvasAnim.SetBool ("MainMenu", false);
				canvasAnim.SetBool ("GamePlay", false);
				canvasAnim.SetBool ("Paused", false);
				canvasAnim.SetBool ("PausedInstructions", false);
				canvasAnim.SetBool ("Quit", false);
				//canvasAnim.SetBool (gameover, true);
				lives = 3;
				lives1.gameObject.SetActive (false);
				lives3.gameObject.SetActive (true);
			}
		}

	}

}