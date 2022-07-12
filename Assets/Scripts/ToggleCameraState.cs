using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class ToggleCameraState : MonoBehaviour {
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] GameObject commander;
    [SerializeField] GameObject RTSMover;

    void Start() {
        cameraFollow.Setup(() => commander.transform.position);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (!RTSMover.activeSelf) {
                RTSCamera();
            }
            else {
                CommanderCamera();
            }
        }
    }

    void CommanderCamera() {
        commander.GetComponent<PlayerMovement>().enabled = true;
        commander.GetComponent<PlayerAim>().enabled = true;
        cameraFollow.SetGetCameraFollowPositionFunc(() => commander.transform.position);
        RTSMover.SetActive(false);
    }

    void RTSCamera() {
        RTSMover.transform.position = commander.transform.position;
        cameraFollow.SetGetCameraFollowPositionFunc(() => RTSMover.transform.position);
        commander.GetComponent<PlayerMovement>().enabled = false;
        commander.GetComponent<PlayerAim>().enabled = false;
        RTSMover.SetActive(true);
    }
}
