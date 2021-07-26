using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInstantiator : MonoBehaviour {

	[SerializeField] private List<Instantiatorexplosion>instantiators;
	[SerializeField] private float delayBetweenInstantiators;

	public int InstantiatorCount{
		get{
			return instantiators.Count;
		}
	}

	public void InstantiateInSequence(){
		StartCoroutine (InstantiatorSequence());
	}

	public void InstantiateByIndex(int index){
		var instantiator = instantiators [index];
		instantiator.DoInstantiate ();	
	}

	private IEnumerator InstantiatorSequence(){
		foreach(var instan in instantiators){
			instan.DoInstantiate ();
			yield return new WaitForSeconds (delayBetweenInstantiators);
		}
	}
}
