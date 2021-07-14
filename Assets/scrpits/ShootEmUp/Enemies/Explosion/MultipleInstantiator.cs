using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInstantiator : MonoBehaviour {

	[SerializeField] private List<Instantiatorexplosion>instantiators;
	[SerializeField] private float delayBetweenInstantiators;

	public void InstantiateInSequence(){
		StartCoroutine (InstantiatorSequence());
	}
	private IEnumerator InstantiatorSequence(){
		foreach(var instan in instantiators){
			instan.DoInstantiate ();
			yield return new WaitForSeconds (delayBetweenInstantiators);
		}
	}
}
