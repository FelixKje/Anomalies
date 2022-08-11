using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Utility;

public class Builder : MonoBehaviour , IBuilding {
     [SerializeField] GameObject building;
     [SerializeField] int cost;
     public void Build() {
          Vector3 buildPosition = Utilities.GetMouseWorldPosition();
          Instantiate(building, buildPosition, quaternion.identity);
          Pathfinding.Instance.Grid.GetXY(buildPosition, out int x, out int y);
          Pathfinding.Instance.Grid.GetGridObject(x, y).isWalkable = false;
     }
}
