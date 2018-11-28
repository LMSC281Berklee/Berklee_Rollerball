//LMSC-281 Basic Audio Concepts
//Berklee College of Music
//Fall 2018 - Jeanine Cowen
//adapted from Unity Tutorial


using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour {

	public int xVal = 15;
	public int yVal = 30;
	public int zVal = 45;
	

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (xVal, yVal, zVal) * Time.deltaTime * Random.value);
	}
}
