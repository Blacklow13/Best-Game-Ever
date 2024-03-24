using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    public EnemyHealth enemyHealth;

    public PlayerController player;

    public float viewAngle;

    private NavMeshAgent _navMeshAgent;

    private int Destination_index;

    private bool _isPlayerNoticed;

    public float damage = 30;

    private PlayerHealth _playerHealth;

    // Start is called before the first frame update

    public bool IsAlive()
    {
        return enemyHealth.IsAlive();
    }

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

        AttackUpdate();

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
    private void AttackUpdate()
    {
        if (_isPlayerNoticed  && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.DealDamage(damage * Time.deltaTime);
        }
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isPlayerNoticed )
        { 
            PickNewPatrolPoint();
        }
    }
    private void InitComponentLinks() {

        _navMeshAgent = GetComponent<NavMeshAgent>();

        _playerHealth = player.GetComponent<PlayerHealth>();


    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}
