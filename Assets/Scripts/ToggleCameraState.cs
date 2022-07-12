using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class ToggleCameraState : MonoBehaviour {
    [SerializeField] GameObject Commander;
    [SerializeField] GameObject RTSMover;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (!RTSMover.activeSelf) {
                RTSMover.transform.position = Commander.transform.position;
                Commander.GetComponent<PlayerMovement>().enabled = false;
                RTSMover.SetActive(true);
            }
            else {
                Commander.GetComponent<PlayerMovement>().enabled = true;
                RTSMover.SetActive(false);
            }
        }
    }

    void TopDown() {
        
    }
}
