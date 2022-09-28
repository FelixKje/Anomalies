using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;
using UnityEngine.Pool;
using Utility;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform muzzlePos;
    [SerializeField][Range(0f,90f)] float bulletSpread = 0.05f;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float weaponFireRate = 0.2f;

    ObjectPool<Bullet> bulletPool;
    float timePassed;


    void Awake() => bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool, default,true, 100 );
    void Start() {
        GetComponent<PlayerAim>().ShootInputPressed += Shoot;
    }

    Bullet CreateBullet() {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletPool);
        return bullet;
    }
    void OnTakeBulletFromPool(Bullet bullet) {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = muzzlePos.position;
    }

    void OnReturnBulletToPool(Bullet bullet) {
        bullet.gameObject.SetActive(false);
    }

    void Shoot() {
        if (Input.GetMouseButtonDown(0)) timePassed = weaponFireRate;
        timePassed += Time.deltaTime;
        if (timePassed >= weaponFireRate) {
            Debug.Log(bulletPool.CountInactive);
                
            var bullet = bulletPool.Get();
            var mousePosition = Utilities.GetMouseWorldPosition();

            var randomHitPosX = Random.Range(mousePosition.x - bulletSpread, mousePosition.x + bulletSpread);
            var randomHitPosY = Random.Range(mousePosition.y - bulletSpread, mousePosition.y + bulletSpread);
            var randomHitPos = new Vector3(randomHitPosX, randomHitPosY);
                
            var direction = (randomHitPos - transform.position).normalized;
                
            bullet.Setup(direction);
            timePassed -= weaponFireRate;
        }
    }
}
