//LMSC-281 Basic Audio Concepts
//Berklee College of Music
//Fall 2018 - Jeanine Cowen

using UnityEngine;
using System.Collections;

public static class AudioTools {

	public static IEnumerator FadeOut (AudioSource audioSource, float fadeTime) {

		float startVolume = audioSource.volume;

		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

			yield return null;
		}

		audioSource.Stop ();
		audioSource.volume = startVolume;
	}

	public static IEnumerator FadeIn (AudioSource audioSource, float fadeTime) {
		float targetVolume = audioSource.volume;
		float startVolume = targetVolume/fadeTime;
		audioSource.volume = startVolume;

		audioSource.Play ();

		while (audioSource.volume < targetVolume) {
			audioSource.volume += startVolume * Time.deltaTime / fadeTime;

			yield return null;
		}
	}



}