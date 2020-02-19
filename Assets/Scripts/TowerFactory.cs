using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 5;

    int numTowers = 0;

    public void AddTower(Waypoint baseWaypoint) {

        if (numTowers < maxTowers) {

            InstantiateNewTower(baseWaypoint);
        } else {

            MoveExistingTower();
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint) {

        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        numTowers++;
    }

    private static void MoveExistingTower() {

        Debug.Log("Max towers reached");
    }
}
