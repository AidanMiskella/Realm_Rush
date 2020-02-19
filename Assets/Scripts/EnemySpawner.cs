using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] [Range(0.1f,120f)] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;

    // Start is called before the first frame update
    void Start() {

        StartCoroutine(RepeatSpawnEnemies());
    }

    IEnumerator RepeatSpawnEnemies() {

        while (true) {

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
