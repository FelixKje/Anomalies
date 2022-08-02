using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class GameRTSController : MonoBehaviour {

    [SerializeField] Transform selectionAreaTransform;

    Vector3 startPosition;
    List<UnitRTS> selectedUnitRTSList;
    

    void Awake() {
        selectedUnitRTSList = new List<UnitRTS>();
        selectionAreaTransform.gameObject.SetActive(false);
    }
    void Update() {
        HandleSelectingUnits();
        HandleCommandingSelectedUnits();
    }

    void HandleCommandingSelectedUnits() {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 moveToPosition = Utilities.GetMouseWorldPosition();
            foreach (var unit in selectedUnitRTSList) {
                unit.MoveTo(moveToPosition);
            }
        }
    }

    void HandleSelectingUnits() {
        if (Input.GetMouseButtonDown(0)) {
            selectionAreaTransform.gameObject.SetActive(true);
            startPosition = Utilities.GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0)) {
            Vector3 currentMousePosition = Utilities.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
            );
            
            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
            );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }

        if (Input.GetMouseButtonUp(0)) {
            selectionAreaTransform.gameObject.SetActive(false);
            
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
        }
    }
}
