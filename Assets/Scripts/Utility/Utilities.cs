using UnityEngine;
namespace Utility {
    public static class Utilities 
    {
        public static Vector3 GetMouseWorldPosition() {
            Vector3 vector3 = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vector3.z = 0f;
            return vector3;
        }

        public static Vector3 GetMouseWorldPositionWithZ() {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
            var worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }
    }
}
