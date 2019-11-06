using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float DetectionRadius;
    public float AttackDistance;
    GameObject Player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private enum ZOMSTATE
    {
        idle,
        awake
    }

    private ZOMSTATE CurrentState;

    // Update is called once per frame
    void Update()
    {

        switch (CurrentState)
        {
            case ZOMSTATE.idle:
                if (Vector3.Distance(Player.transform.position, transform.position) < DetectionRadius)
                {
                    if (Physics.Raycast(transform.position, Player.transform.position - transform.position, out RaycastHit hit) && hit.transform.CompareTag("Player"))
                    {
                        CurrentState = ZOMSTATE.awake;
                        agent.isStopped = false;
                    }
                }
                break;
            case ZOMSTATE.awake:
                agent.SetDestination(Player.transform.position);
                if (Vector3.Distance(Player.transform.position, transform.position) < AttackDistance)
                {
                    agent.isStopped = true;
                }
                else if (Vector3.Distance(Player.transform.position, transform.position) > DetectionRadius || !(Physics.Raycast(transform.position, Player.transform.position - transform.position, out RaycastHit hit) && hit.transform.CompareTag("Player")))
                {
                    CurrentState = ZOMSTATE.idle;
                    agent.isStopped = true;
                }
                break;
            default:
                break;
        }
    }
}
