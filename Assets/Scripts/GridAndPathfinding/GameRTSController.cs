using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameRTSController : MonoBehaviour {
    List<UnitRTS> selectedUnitRTSList;
    Vector3 startPosition;

    void Awake() {
        selectedUnitRTSList = new List<UnitRTS>();
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            startPosition = Utilities.GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0)) {
            
            Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(startPosition, Utilities.GetMouseWorldPosition());
            foreach (var unitRTS in selectedUnitRTSList) {
                unitRTS.SetSelectedVisible(false);
            }
            selectedUnitRTSList.Clear();
            foreach (var collider in collider2Ds) {
                UnitRTS unitRts = collider.GetComponent<UnitRTS>();
                if (unitRts != null) {
                    unitRts.SetSelectedVisible(true);
                    selectedUnitRTSList.Add(unitRts);
                }
            }
            Debug.Log(selectedUnitRTSList.Count);
        }
    }
}
