using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    private NavMeshAgent _agent;

    private void OnDisable()
    {
        PlayerDeath.onEnemyStoped -= StopMove;
    }

    private void OnEnable()
    {
        PlayerDeath.onEnemyStoped += StopMove;
    }


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
        _agent.speed = _enemy.EnemyConfig.MoveSpeed;
    }


    public void StopMove()
    {
        _agent.isStopped = true;       
    }

    private void Update()
    {
        _agent.SetDestination(Player.Instance.transform.position);
    }

}
