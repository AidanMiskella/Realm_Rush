using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] [Range(0.1f,120f)] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    // Start is called before the first frame update
    void Start() {

        StartCoroutine(RepeatSpawnEnemies());
    }

    IEnumerator RepeatSpawnEnemies() {

        while (true) {

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
