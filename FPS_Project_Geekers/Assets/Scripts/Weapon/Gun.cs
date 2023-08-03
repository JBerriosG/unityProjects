using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Punto de spawn de la bala.
    [SerializeField] private Transform spawnPoint;
    
    //Referencia al objeto bala que sera instanciado.
    [SerializeField] private GameObject bullet;

    //Fuerza con la que la bala saldra disparada.
    [SerializeField] private float shotForce = 1500f;
    //Cadencia de Tiro entre balas paa asi diferenciar entre tipos de armas.
    [SerializeField] private float shotRate = 0.5f;
    //Cadencia de Tiro entre recargas.
    private float shotRateTime = 0;

    void Update()
    {
        //Se consulta si es que fue presionado el click izquierdo del mouse.
        if (Input.GetButtonDown("Fire1") && Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
        {
            GameManager.Instance.gunAmmo--;
            //creamos un nuevo GameObject.
            GameObject newBullet;
            //Instanciamos la bala original, la position y rotation de nuestro spawnPoint
            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            //Obtenemos el RigigBody de la nueva instancia y le añadimos una fuerza hacia adelante multiplicada por la fuerza que asignamos antes.
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            //Se recalcula el tiempo en que se podrá disparar
            shotRateTime = Time.time + shotRate;
            //Se destruye el objeto para que no permanezca luego de dispararlo.
            Destroy(newBullet, 2);
        }

    }
}
