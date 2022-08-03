using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Utility;

public class Builder : MonoBehaviour , IBuilding {
     [SerializeField] int cost;

     public void Build(GameObject buildingType, int cost) {
          Vector3 buildPosition = Utilities.GetMouseWorldPosition();
          Instantiate(gameObject, buildPosition, quaternion.identity);
     }

}
