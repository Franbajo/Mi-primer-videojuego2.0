using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroller : MonoBehaviour {
	
	public float scrollSpeed;

	[SerializeField] private MeshRenderer Texturilla;

	void Update () {
		Vector2 offset = new Vector2 (0, Time.time * scrollSpeed);
		Texturilla.material.mainTextureOffset = offset;
	}
}
