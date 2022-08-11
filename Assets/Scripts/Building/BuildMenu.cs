using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour {
    [SerializeField] Builder drill;
    bool toggleBuildMenu;

    
    void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            toggleBuildMenu = !toggleBuildMenu;
            Debug.Log(toggleBuildMenu);
        }
        if (toggleBuildMenu) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                drill.Build();
            }
        }
    }
}
