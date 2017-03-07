using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

    public GameObject[] Lights;
	public GameObject[] Basement;
	public GameObject[] Entry;
	public GameObject[] HallwayRl;
	public GameObject[] HallwayRu;
	public GameObject[] JohnsRoom;
	public GameObject[] Library;
	public GameObject[] Study;
	public GameObject[] SecretPassage;
	public GameObject[] DiningRoom;
	public GameObject[] HallwayL;
	public GameObject[] HallwayMl;
	public GameObject[] ServantsRoom;
	public GameObject[] HallwayMu;
	public GameObject[] Exit;

	private 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider trigger){

		Debug.Log ("grrgrrgrr");



		switch (trigger.tag) {
			case "Basement":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for (int i = 0; i < Basement.Length; i++) {
					Basement [i].SetActive (true);
				}
				break;
            case "Entry":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
                for(int i = 0; i < Entry.Length; i++){
                    Entry [i].SetActive (true);
				}
				break;
			case "HallwayRl":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < HallwayRl.Length; i++){
					HallwayRl [i].SetActive (true);
				}
				break;
			case "HallwayRu":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < HallwayRu.Length; i++){
					HallwayRu [i].SetActive (true);
				}
				break;
			case "JohnsRoom":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < JohnsRoom.Length; i++){
					JohnsRoom [i].SetActive (true);
				}
				break;
			case "Library":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < Library.Length; i++){
					Library [i].SetActive (true);
				}
				break;
			case "Study":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < Study.Length; i++){
					Study [i].SetActive (true);
				}
				break;
			case "SecretPassage":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < SecretPassage.Length; i++){
					SecretPassage [i].SetActive (true);
				}
				break;
			case "DiningRoom":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < DiningRoom.Length; i++){
					DiningRoom [i].SetActive (true);
				}
				break;
			case "HallwayL":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < HallwayL.Length; i++){
					HallwayL [i].SetActive (true);
				}
				break;
			case "HallwayMl":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < HallwayMl.Length; i++){
					HallwayMl [i].SetActive (true);
				}
				break;
			case "ServantsRoom":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < ServantsRoom.Length; i++){
					ServantsRoom [i].SetActive (true);
				}
				break;
			case "HallwayMu":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < HallwayMu.Length; i++){
					HallwayMu [i].SetActive (true);
				}
				break;
			case "Exit":
				for (int i = 0; i < Lights.Length; i++) {
					Lights [i].SetActive (false);
				}
				for(int i = 0; i < Exit.Length; i++){
					Exit [i].SetActive (true);
				}
				break;
            
		}

		Debug.Log (trigger.GetComponent<Collider>().gameObject.name);


	}
}
