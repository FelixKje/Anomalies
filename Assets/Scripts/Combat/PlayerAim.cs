using Unity.Mathematics;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace Movement {
    public class PlayerAim : MonoBehaviour {
        [SerializeField] Transform weapon;
        [SerializeField][Range(0f,90f)] float bulletSpread = 0.05f;
        [SerializeField] GameObject bulletGameObject;
        [SerializeField] float weaponFireRate = 0.2f;
        float timePassed;

        bool isDebug;
        void Update() {
            Aim();
            Shoot();
        }
        void Shoot() {
            if (timePassed > weaponFireRate) {
                timePassed += Time.deltaTime;
            }
            if (Input.GetMouseButton(0)) {
                
                timePassed += Time.deltaTime;
                if (timePassed >= weaponFireRate) {
                    var bullet = Instantiate(bulletGameObject);
                    bullet.transform.position = weapon.position;
                
                    var mousePosition = Utilities.GetMouseWorldPosition();
                    var direction = (mousePosition - transform.position).normalized;

                    var randomHitPosX = Random.Range(mousePosition.x - bulletSpread, mousePosition.x + bulletSpread);
                    var randomHitPosY = Random.Range(mousePosition.y - bulletSpread, mousePosition.y + bulletSpread);
                    var randomHitPos = new Vector3(randomHitPosX, randomHitPosY, direction.z);
                
                    bullet.GetComponent<Bullet>().Setup(direction);
                    timePassed -= weaponFireRate;
                }
            }
        }
        void Aim() {
            Vector3 mousePosition = Utilities.GetMouseWorldPosition();
            Vector3 aimDirection = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            weapon.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
