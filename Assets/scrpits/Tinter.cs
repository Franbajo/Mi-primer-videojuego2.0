using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tinter : MonoBehaviour {
	[SerializeField] private SpriteRenderer spriteRender; //Sprite de referencia.
	public Material tintColor;
	[SerializeField] private float timeToGoBack;
	private Material originalColor;

	public void Awake(){
		originalColor = spriteRender.material;

	}

	public void DoTint(){

		spriteRender.material = tintColor;
		Invoke ("TintBackToOriginal", timeToGoBack);
	}
	public void TintBackToOriginal(){
		spriteRender.material = originalColor;
	}
}
