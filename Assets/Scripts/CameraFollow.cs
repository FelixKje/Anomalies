using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    [SerializeField] float cameraMoveSpeed =2f;

    Camera myCamera;
    Func<Vector3> GetCameraFollowPositionFunc;
    Func<float> GetCameraZoomFunc;

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }

    void Start() {
        myCamera = transform.GetComponent<Camera>();
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    void Update() {
        HandleMovement();
        HandleZoom();
    }

    void HandleMovement() {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);

        if (distance > 0) {
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if (distanceAfterMoving > distance) {
                newCameraPosition = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
    }

    void HandleZoom() {
        float cameraZoom = GetCameraZoomFunc();

        float cameraZoomDifference = cameraZoom - myCamera.orthographicSize;
        float cameraZoomSpped = 1f;
        
        myCamera.orthographicSize += cameraZoomDifference * cameraZoomSpped * Time.deltaTime;

        if (cameraZoomDifference > 0) {
            if (myCamera.orthographicSize > cameraZoom) {
                myCamera.orthographicSize = cameraZoom;
            }
        }else {
            if (myCamera.orthographicSize < cameraZoom) {
                myCamera.orthographicSize = cameraZoom;
            }
        }
    }
}
