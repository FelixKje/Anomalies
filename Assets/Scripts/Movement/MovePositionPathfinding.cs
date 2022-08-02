using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionPathfinding : MonoBehaviour, IMovePosition {
    
    List<Vector3> pathVectorList;
    int pathIndex = -1;

    public void SetMovePosition(Vector3 movePosition) {
        Debug.Log("Trying to find path");
        pathVectorList = Pathfinding.Instance.FindPath(transform.position, movePosition);
        if (pathVectorList.Count > 0) {
            pathIndex = 0;
            foreach (var pathNode in pathVectorList) {
                Debug.Log(pathNode);
            }
            Debug.Log(pathVectorList.Count);
        }
    }

    void Update() {
        if (pathIndex != -1) {
            Vector3 nextPathPosition = pathVectorList[pathIndex];
            Vector3 moveVelocity = (nextPathPosition - transform.position).normalized;
            GetComponent<IMoveVelocity>().SetVelocity(moveVelocity);

            float reachedPositionDistance = 2f;
            Debug.Log(Vector3.Distance(transform.position, nextPathPosition));
            if (Vector3.Distance(transform.position, nextPathPosition) < reachedPositionDistance) {
                Debug.Log("Node reached next index:" + pathIndex);
                pathIndex++;
                if (pathIndex >= pathVectorList.Count) {
                    pathIndex = -1;
                }
            }
        } else {
            GetComponent<IMoveVelocity>().SetVelocity(Vector3.zero);
        }
        
    }

}
