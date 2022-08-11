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
          Instantiate(gameObject, buildPosition, quaternion.identity);
          Vector3 gridPosition = new Vector3();
     }

}
