using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] [Range(0.1f,120f)] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score;

    // Start is called before the first frame update
    void Start() {

        spawnedEnemies.text = score.ToString();
        StartCoroutine(RepeatSpawnEnemies());
    }

    IEnumerator RepeatSpawnEnemies() {

        while (true) {

            UpdateScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void UpdateScore() {

        score++;
        spawnedEnemies.text = score.ToString();
    }
}
