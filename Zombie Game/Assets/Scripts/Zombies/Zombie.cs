using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float DetectionRadius;
    public float AttackDistance;
    public float DespawnTimer;
    private GameObject Player;
    private NavMeshAgent Agent;
    private Animator Ani;
    private Collider Collider;
    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponentInChildren<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
        Collider = GetComponent<CapsuleCollider>();
    }

    private enum ZOMSTATE
    {
        idle,
        Walking,
        Dead
    }

    private ZOMSTATE CurrentState;

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case ZOMSTATE.idle:
                if (InRangeOfPlayer())
                {
                    if (CanSeePlayer())
                    {
                        Ani.SetBool("Walking", true);
                        CurrentState = ZOMSTATE.Walking;
                        Agent.isStopped = false;
                    }
                }
                break;
            case ZOMSTATE.Walking:
                Agent.SetDestination(Player.transform.position);
                if (CanHitPlayer())
                {
                    Ani.SetBool("Walking", false);
                    Agent.isStopped = true;
                }
                else if (!InRangeOfPlayer() || !CanSeePlayer())
                {
                    Ani.SetBool("Walking", false);
                    CurrentState = ZOMSTATE.idle;
                    Agent.isStopped = true;
                }
                else if (!CanHitPlayer())
                {
                    Ani.SetBool("Walking", true);
                    Agent.isStopped = false;
                }
                break;
            default:
                break;
        }
    }

    private bool CanSeePlayer()
    {
        return Physics.Raycast(transform.position, Player.transform.position - transform.position, out RaycastHit hit) && hit.transform.CompareTag("Player");
    }

    private bool InRangeOfPlayer()
    {
        return Vector3.Distance(Player.transform.position, transform.position) < DetectionRadius;
    }

    private bool CanHitPlayer()
    {
        return Vector3.Distance(Player.transform.position, transform.position) < AttackDistance;
    }

    public bool Die()
    {
        if (CurrentState != ZOMSTATE.Dead)
        {
            CurrentState = ZOMSTATE.Dead;
            Collider.enabled = false;
            Agent.enabled = false;
            //agent.isStopped = true;
            Ani.SetTrigger("Die");
            StartCoroutine(Despawn());
            return true;
        }
        return false;
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(DespawnTimer);
        Destroy(gameObject);
    }
}
