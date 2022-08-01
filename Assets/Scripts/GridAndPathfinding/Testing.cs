using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Testing : MonoBehaviour {
    Pathfinding pathfinding;
    void Start() {
        pathfinding = new Pathfinding(10, 10);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = Utilities.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mousePosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(5, 5, x, y);
            if (path != null) {
                for (int i = 0; i < path.Count - 1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green, 100f);
                }
            }
        }
            
    }
}
