using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] GameObject explotionEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explotionEffect, transform.position, transform.rotation);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
            Destroy(gameObject);
    }
}
