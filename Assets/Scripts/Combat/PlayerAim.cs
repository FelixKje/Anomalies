using UnityEngine;
using Utility;

namespace Movement {
    public class PlayerAim : MonoBehaviour {
        [SerializeField] Transform weapon;
        void Update() {
            Aim();
            Shoot();
        }
        void Shoot() {
            if (Input.GetMouseButtonDown(0)) {
                var mousePosition = Utilities.GetMouseWorldPosition();
                var direction = (mousePosition - transform.position).normalized;
                
                Debug.DrawLine(weapon.position, mousePosition, Color.red, 1f);
                Debug.Log(direction);
                
                Debug.Log(Physics.Raycast(weapon.position, direction, 100));
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
