using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Barracks : MonoBehaviour {
    [SerializeField] GameObject unit;
    [SerializeField] float spawnTimer;
    
    IEnumerator Start() {
        while (true) {
            Instantiate(unit, transform.position + Vector3.right, quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
