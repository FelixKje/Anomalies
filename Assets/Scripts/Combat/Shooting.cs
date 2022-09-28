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

    IObjectPool<Bullet> bulletPool;
    float timePassed;


    void Awake() => bulletPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBulletFromPool, OnReturnBulletToPool, default,true, 100 );
    

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

    public void Shoot(Vector3 shootPos) {
        timePassed += Time.deltaTime;
        if (timePassed >= weaponFireRate) {
            var bullet = bulletPool.Get();

            var randomHitPosX = Random.Range(shootPos.x - bulletSpread, shootPos.x + bulletSpread);
            var randomHitPosY = Random.Range(shootPos.y - bulletSpread, shootPos.y + bulletSpread);
            var randomHitPos = new Vector3(randomHitPosX, randomHitPosY);
                
            var direction = (randomHitPos - transform.position).normalized;
                
            bullet.Setup(direction);
            timePassed -= weaponFireRate;
        }
    }
}
