using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [SerializeField] Transform gunExit;
    [SerializeField] float fireRate = 0.5f;
    float cooldown;

    void Update() {
        if (Input.GetMouseButton(0)) {
            ShootGun();
        }
    }

    void ShootGun() {
        cooldown += Time.deltaTime;
        if (cooldown > fireRate) {
            Debug.Log("Bang");
            cooldown -= fireRate;
        }
    }
}
