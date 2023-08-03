using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{

    [SerializeField] private float throwForce = 500;
    [SerializeField] private GameObject grenadePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject newGrenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
    }
}
