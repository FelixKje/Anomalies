using UnityEngine;
using Utility;

namespace Movement {
    public class PlayerAim : MonoBehaviour {
        [SerializeField] Transform weapon;
        void Update() {
            Aim();
        }
        void Aim() {
            Vector3 mousePosition = Utilities.GetMouseWorldPosition();
            Vector3 aimDirection = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            weapon.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
    
    
}
