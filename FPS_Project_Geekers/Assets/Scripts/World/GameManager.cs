using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text ammoText;

    [SerializeField] private Text healthText;

    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;
    public int health = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }

    public void LoseHealth(int healthToReduce) 
    {
        health -= healthToReduce;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Haz Muerto!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
