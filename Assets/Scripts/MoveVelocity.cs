using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity {
    [SerializeField] float moveSpeed;
    
    Vector3 velocity;
    Rigidbody2D rigidbody2D;

    void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocity) {
        this.velocity = velocity;
    }

    void FixedUpdate() {
        rigidbody2D.velocity = velocity * moveSpeed;
    }
}
