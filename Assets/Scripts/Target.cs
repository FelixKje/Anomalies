using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Damage() {
        //TODO: replace with pool
        Destroy(gameObject);
    }
}
