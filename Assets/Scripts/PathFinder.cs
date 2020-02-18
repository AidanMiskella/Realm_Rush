using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Start is called before the first frame update
    void Start() {

        LoadBlocks();
        ColorStartAndEnd();
    }

    private void ColorStartAndEnd() {

        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks() {

        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {

            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos)) {

                Debug.LogWarning("Overlapping block " + waypoint);
            } else {

                grid.Add(gridPos, waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
