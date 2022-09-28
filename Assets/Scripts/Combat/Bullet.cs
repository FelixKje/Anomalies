using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour {
    [SerializeField] float moveSpeed = 60f;
    [SerializeField] float lifeTime = 2f;


    float timePassed;
    IObjectPool<Bullet> _pool;
    Vector3 _shootDir;

    void OnEnable() {
        timePassed = 0;
    }
    public void Setup(Vector3 shootDir) {
        this._shootDir = shootDir;
    }

    public void SetPool(IObjectPool<Bullet> pool) => this._pool = pool;

    void Update() {
        transform.position += _shootDir * moveSpeed * Time.deltaTime;
        timePassed += Time.deltaTime;
        if (timePassed > lifeTime) 
            _pool.Release(this);
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        Target target = other.GetComponent<Target>();
        if (target != null) {
            target.Damage();
            _pool.Release(this);
        }
    }
}
