using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsBehaviour : MonoBehaviour
{
    Rigidbody rb;
    private float forcePush;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forcePush = Random.Range(4000f, 6000f);
        float width = Random.Range(-500, 500);
        float height = Random.Range(400, 800);
        rb.AddForce(new Vector3(width, height, forcePush));
        rb.AddTorque(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)));
        Destroy(gameObject, 10f);
    }
}
