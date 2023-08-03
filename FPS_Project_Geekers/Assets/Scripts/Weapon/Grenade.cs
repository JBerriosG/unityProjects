using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] private float delay = 3f;

    float countdown;

    [SerializeField] private float radius = 5f;

    [SerializeField] private float explotionForce = 70f;

    bool exploded = false;

    [SerializeField] GameObject explotionEffect;
    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && exploded == false)
        {
            Explode();
            exploded = true;
        }
    }

    void Explode ()
    {
        Instantiate(explotionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var rangeObjects in colliders)
        {
            
            if (rangeObjects.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.AddExplosionForce(explotionForce * 10, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
