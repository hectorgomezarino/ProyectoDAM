using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per framefile:///home/hgomez/2DTestTutorialNewVersion/Assets/MenuChange.cs

	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void changeToScene (int sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void exitGame() {
        Application.Quit(); //The code will not work if you're testing it from the scene editor. 
    }
}
