using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour {

    GameObject selectedGameObject;

    void Awake() {
        selectedGameObject = transform.Find("Selected").gameObject;
    }

    public void SetSelectedVisible(bool visible) {
        selectedGameObject.SetActive(visible);
    }
}
