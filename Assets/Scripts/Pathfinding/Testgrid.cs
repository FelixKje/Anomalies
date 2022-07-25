using System;
using UnityEngine;
using Utility;
namespace Pathfinding {
    public class Testgrid : MonoBehaviour {
        Grid grid;
        void Start() {
            grid = new Pathfinding.Grid(4, 2, 5f, new Vector3(-2 * 5f,-1 * 5f));
        }

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                grid.SetValue(Utilities.GetMouseWorldPosition(), 56);
            }
            if (Input.GetMouseButtonDown(1)) {
                Debug.Log(grid.GetValue(Utilities.GetMouseWorldPosition()));
            }
        }
    }
}
