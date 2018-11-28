//LMSC-281 Basic Audio Concepts
//Berklee College of Music
//Fall 2018 - Jeanine Cowen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("If you were in build, the game would have just quit!");
        }
    }
}
