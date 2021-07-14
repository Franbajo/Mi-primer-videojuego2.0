using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnController : MonoBehaviour {
	[SerializeField]private List <EnemyWavesConfig> wavesConfig;
	[SerializeField]private  float initialWaitTime;
	[SerializeField]private  float cadenceBetweenWaves;

	private void Start(){

		StartCoroutine(EnemySpawnerCoroutine ());
	}

	private IEnumerator EnemySpawnerCoroutine(){
		yield return new WaitForSeconds (initialWaitTime);
		foreach(var wave in wavesConfig){
			foreach(var enemie in wave.enemies){
				Vector3 enemyPosition = Vector3.zero;
				if (enemie.useSpecificXPosition) {
					enemyPosition = enemie.spawnReferencePosition;
				} else {
					enemyPosition = new Vector3 (Random.Range (-enemie.spawnReferencePosition.x, enemie.spawnReferencePosition.x), enemie.spawnReferencePosition.y, enemie.spawnReferencePosition.z);
				}
				SpawnEnemy (enemie.enemyPrefab, enemie.config, enemyPosition);
				yield return new WaitForSeconds (wave.cadence);
			}
			yield return new WaitForSeconds (cadenceBetweenWaves);
		}
	}

	public void SpawnEnemy(EnemyController enemyPrefab, EnemyConfig config ,Vector3 enemyPosition){
		if(enemyPrefab!=null){
		var enemyInstance= Instantiate (enemyPrefab,  enemyPosition, Quaternion.identity);
		enemyInstance.config = config;
		}
	}
}
