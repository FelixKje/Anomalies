using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour {

    GameObject selectedGameObject;
    IMovePosition movePosition;

    void Awake() {
        selectedGameObject = transform.Find("Selected").gameObject;
        movePosition = GetComponent<IMovePosition>();
        SetSelectedVisible(false);
    }

    public void SetSelectedVisible(bool visible) {
        selectedGameObject.SetActive(visible);
    }

    public void MoveTo(Vector3 targetPosition) {
        movePosition.SetMovePosition(targetPosition);
    }
}
