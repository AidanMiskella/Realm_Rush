using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint) {

        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit) {

            InstantiateNewTower(baseWaypoint);
        } else {

            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint) {

        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;

        // set the basewaypoint
        // put new tower on queue
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint baseWaypoint) {

        var oldTower = towerQueue.Dequeue();
        baseWaypoint.isPlaceable = true;
        // set basewaypoint
        towerQueue.Enqueue(oldTower);
    }
}
