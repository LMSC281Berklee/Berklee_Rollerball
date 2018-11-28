//LMSC-281 Basic Audio Concepts
//Berklee College of Music
//Fall 2018 - Jeanine Cowen
//adapted from Unity Tutorial

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	private int count;
	AudioSource myAudio;
	public AudioClip winAudio;

	public Rigidbody rb;

	void Start () {
		count = 0;
		SetCountText ();
		winText.text = "";
		rb = GetComponent<Rigidbody>();
		myAudio = GetComponent<AudioSource>();

	}

	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Pickup") {
			myAudio.Play();
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText (); 
		}

	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "YOU WIN!!!";
			myAudio.clip = winAudio;
			myAudio.time = 6.5f;
			myAudio.Play();
		}
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "West Wall") {
			AudioSource otherAudio = other.gameObject.GetComponent<AudioSource>();

			//use the static method FadeOut by passing in the AudioSource and a time for the fade to happen
			StartCoroutine (AudioTools.FadeOut (otherAudio, 3.0f));

			//use the line below to just stop the sound abruptly
//			otherAudio.Stop ();
		}

		if (other.gameObject.name == "East Wall") {
			AudioSource otherAudio = other.gameObject.GetComponent<AudioSource>();

			//use the static method FadeIn by passing in the AudioSource and a time for the fade to happen
			StartCoroutine (AudioTools.FadeIn (otherAudio, 3.0f));

			//use the line below to just start the sound abruptly
			//			otherAudio.Play ();
		}

		if (other.gameObject.name == "North Wall") {
			AudioSource otherAudio = other.gameObject.GetComponent<AudioSource>();
			if (otherAudio.isPlaying) {
				otherAudio.Pause();
			}
			else {
				otherAudio.Play();
			}
		}

	}


}
