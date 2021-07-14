using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	[SerializeField]private float TimeDelay;
	//[SerializeField] private List<Instantiatorexplosion>instantiators;
	//[SerializeField] private Animator anim;
	public void DoDestroy(){
		StartCoroutine (timeDeath());
	}


	public IEnumerator timeDeath(){
		yield return new WaitForSeconds (TimeDelay);
		Destroy(this.gameObject); //gameObject en MonoBehaviur es una referencia a sí mismo como game object
	//	this.anim.Play("Muerte");
	}
}
