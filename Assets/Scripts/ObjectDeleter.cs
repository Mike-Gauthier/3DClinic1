using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        Destroy(col.gameObject);
    }
}
