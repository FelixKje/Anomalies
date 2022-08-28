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
          
          Debug.DrawLine(clickedPosition + Vector3.left, clickedPosition + Vector3.right, Color.white, 100f);
          Debug.DrawLine(clickedPosition + Vector3.up, clickedPosition + Vector3.down, Color.white, 100f);
          
          Pathfinding.Instance.Grid.GetXY(clickedPosition, out int x, out int y);
          
          if (Pathfinding.Instance.Grid.GetGridObject(x, y).isWalkable) {
               Pathfinding.Instance.Grid.GetGridObject(x, y).isWalkable = false;
               
               var offset = Vector3.up * Pathfinding.Instance.Grid.GetCellSize()/2 + Vector3.right * Pathfinding.Instance.Grid.GetCellSize()/2;
               Vector3 buildPosition = Pathfinding.Instance.Grid.GetWorldPosition(x, y);
               
               Debug.DrawLine(buildPosition + new Vector3(-1,0,0), buildPosition + new Vector3(1,0,0), Color.black, 100f);
               Instantiate(building, buildPosition + offset, quaternion.identity);
          }
     }
}
