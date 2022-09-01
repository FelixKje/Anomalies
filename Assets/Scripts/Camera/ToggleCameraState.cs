using Movement;
using UnityEngine;

public class ToggleCameraState : MonoBehaviour {
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] GameObject commanderGameObject;
    [SerializeField] GameObject strategyGameObject;
    
    [SerializeField] float commanderDefaultZoom = 20f;
    [SerializeField] float StrategyDefaultZoom = 50f;
    [SerializeField] float ZoomAmount = 5f;
    

    float zoom = 20f;

    void Start() {
        cameraFollow.Setup(() => commanderGameObject.transform.position, () => zoom);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (!strategyGameObject.activeSelf) {
                RTSCamera();
            }
            else {
                CommanderCamera();
            }
        }
        if (Input.mouseScrollDelta.y > 0) {
            ZoomIn();
        }
        if (Input.mouseScrollDelta.y < 0) {
            ZoomOut();
        }
    }

    void CommanderCamera() {
        
        commanderGameObject.GetComponent<PlayerMovement>().enabled = true;
        commanderGameObject.GetComponent<PlayerAim>().enabled = true;
        
        cameraFollow.SetGetCameraFollowPositionFunc(() => commanderGameObject.transform.position);
        strategyGameObject.SetActive(false);
        zoom = commanderDefaultZoom;
    }

    void RTSCamera() {
        strategyGameObject.transform.position = commanderGameObject.transform.position;
        cameraFollow.SetGetCameraFollowPositionFunc(() => strategyGameObject.transform.position);
        
        //TODO: Make into method that toggles on and off
        commanderGameObject.GetComponent<PlayerMovement>().enabled = false;
        commanderGameObject.GetComponent<PlayerAim>().enabled = false;
        
        strategyGameObject.SetActive(true);
        zoom = StrategyDefaultZoom;
    }
    

    void ZoomIn() {
        if (zoom < 20f) {
            return;
        }
        zoom -= ZoomAmount;
    }
    void ZoomOut() {
        if (zoom > 60f) {
            return;
        }
        zoom += ZoomAmount;
    }
}
