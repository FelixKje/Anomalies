using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] float moveSpeed = 60f;
    Vector3 shootDir;
    public void Setup(Vector3 shootDir) {
        this.shootDir = shootDir;
    }

    void Update() {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }
}
