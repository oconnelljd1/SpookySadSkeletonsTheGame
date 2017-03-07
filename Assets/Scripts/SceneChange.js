#pragma strict

var scene : String;

function Start () {

}

function Update () {

}

function goToCoolScene(){
	if(scene == "Quit"){
		Application.Quit();
	}else{
		SceneManagement.SceneManager.LoadScene(scene);
	}
}