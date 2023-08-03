using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private Transform spawnBulletPoint;

    private Transform playerPosition;

    [SerializeField] private float bulletVelocity = 100f;
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;

        Invoke("ShootPlayer", 3);
    }

    void Update()
    {
        
    }

    void ShootPlayer()
    {
        Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBullet;

        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);

        Invoke("ShootPlayer", 3);
    } 
}
