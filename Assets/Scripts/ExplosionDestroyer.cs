using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem sys;

    void Awake()
    {
        sys = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (sys.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
