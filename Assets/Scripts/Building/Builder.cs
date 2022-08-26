using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Utility;

public class Builder : MonoBehaviour , IBuilding {
     [SerializeField] GameObject building;
     [SerializeField] int cost;
     public void Build() {
          Vector3 clickedPosition = Utilities.GetMouseWorldPosition();
          Pathfinding.Instance.Grid.GetXY(clickedPosition, out int x, out int y);
          if (Pathfinding.Instance.Grid.GetGridObject(x, y).isWalkable) {
               Pathfinding.Instance.Grid.GetGridObject(x, y).isWalkable = false;
               Vector3 buildPosition = Pathfinding.Instance.Grid.GetWorldPosition(x, y);
               Instantiate(building, buildPosition, quaternion.identity);
          }
     }
}
