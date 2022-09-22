using UnityEngine;
using Utility;

namespace Movement {
    public class PlayerAim : MonoBehaviour {
        [SerializeField] Transform weapon;
        [SerializeField][Range(0f,90f)] float bulletSpread = 0.05f;
        void Update() {
            Aim();
            Shoot();
        }
        void Shoot() {
            if (Input.GetMouseButtonDown(0)) {
                var mousePosition = Utilities.GetMouseWorldPosition();
                var direction = (mousePosition - transform.position).normalized;
                
                var randomHitPosX = Random.Range(mousePosition.x - bulletSpread, mousePosition.x + bulletSpread);
                var randomHitPosY = Random.Range(mousePosition.y - bulletSpread, mousePosition.y + bulletSpread);
                var randomHitPos = new Vector3(randomHitPosX, randomHitPosY, direction.z);
                
                Debug.DrawLine(weapon.position, randomHitPos, Color.red, 1f);
                Debug.Log(direction);

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
