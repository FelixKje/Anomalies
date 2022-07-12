using System;
using UnityEngine;
namespace Movement {
    public class MoveTransformVelocity : MonoBehaviour, IMoveVelocity {
        [SerializeField] float MoveSpeed;

        Vector3 VelocityVector;
        
        public void SetVelocity(Vector3 velocityVector) {
            this.VelocityVector = velocityVector;
        }

        void Update() {
            transform.position += VelocityVector * MoveSpeed * Time.deltaTime;
        }
    }
}
