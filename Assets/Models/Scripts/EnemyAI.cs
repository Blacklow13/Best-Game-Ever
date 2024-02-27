using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    public PlayerController player;

    public float viewAngle;

    private NavMeshAgent _navMeshAgent;

    private int Destination_index;

    private bool _isPlayerNoticed;



    // Start is called before the first frame update
    void Start()
    {
        InitComponentLinks();

        PickNewPatrolPoint();
        
}

    // Update is called once per frame
    void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();

        PatrolUpdate();
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance == 0 && !_isPlayerNoticed)
        {
            PickNewPatrolPoint();
        }
    }
    private void InitComponentLinks() {

        _navMeshAgent = GetComponent<NavMeshAgent>();

    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count - 1)].position;
    }
}
