using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    [SerializeField] private NavMeshAgent navMeshAgent;

    [SerializeField] private Transform[] destinations;

    [SerializeField] private float distanceToFollowPath = 2f;

    private int i = 0;

    [Header("----------Follow Player?---------")]
    [SerializeField] private bool followPlayer;

    private GameObject player;

    private float distanceToPlayer;

    [SerializeField] private float distanceToFollowPlayer = 10f;

    void Start()
    {

        navMeshAgent.destination = destinations[0].position;

        player = FindAnyObjectByType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[^1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
