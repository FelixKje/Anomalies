using System;
using Unity.Mathematics;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace Movement {
    public class PlayerAim : MonoBehaviour {
        [SerializeField] Transform weapon;

        public event Action ShootInputPressed;
        void Update() {
            Aim();
            Shoot();
        }
        void Shoot() {
            if (Input.GetMouseButton(0)) {
                if (ShootInputPressed != null)
                    ShootInputPressed.Invoke();
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
