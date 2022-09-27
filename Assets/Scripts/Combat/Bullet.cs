using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] float moveSpeed = 60f;
    [SerializeField] float lifeTime = 2f;
    Vector3 shootDir;
    public void Setup(Vector3 shootDir) {
        this.shootDir = shootDir;
    }

    void Update() {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
        Destroy(gameObject,lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other) {
        Target target = other.GetComponent<Target>();
        Debug.Log("Hit");
        if (target != null) {
            target.Damage();
            Destroy(gameObject);
        }
    }
}
