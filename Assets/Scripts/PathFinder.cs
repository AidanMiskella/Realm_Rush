using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start() {

        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExploreNeighbours();
    }

    private void PathFind() {

        queue.Enqueue(startWaypoint);

        while (queue.Count > 0) {

            var searchCenter = queue.Dequeue();
            print("Searching from " + searchCenter);
            StopIfEndFound(searchCenter);
        }
        print("Finished pathfinding?");
    }

    private void StopIfEndFound(Waypoint searchCenter) {

        if (searchCenter == endWaypoint) {

            isRunning = false;
            print("Finished");
        }
    }

    private void ExploreNeighbours() {

        foreach (Vector2Int direction in directions) {

            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try {

                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch {

                // do nothing
            }
            
        }
    }

    private void ColorStartAndEnd() {

        startWaypoint.SetTopColor(Color.green);
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
