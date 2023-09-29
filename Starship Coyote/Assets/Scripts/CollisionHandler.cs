using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        Debug.Log(this.name + " bumped " + other.gameObject.name);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log($"{this.name} triggered {other.gameObject.name}");
    }
}
