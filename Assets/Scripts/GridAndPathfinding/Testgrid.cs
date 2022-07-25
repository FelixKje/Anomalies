using System;
using UnityEngine;
using Utility;
public class Testgrid : MonoBehaviour {
    Grid<bool> grid;
    void Start() { 
        grid = new Grid<bool>(4, 2, 5f, new Vector3(-2 * 5f,-1 * 5f));
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(Utilities.GetMouseWorldPosition(), true);
        }
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log(grid.GetValue(Utilities.GetMouseWorldPosition()));
        }
    }
}
