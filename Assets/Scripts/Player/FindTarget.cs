using UnityEngine;

public class TakeTarget : MonoBehaviour
{
    private float _lookAtDistance = 3f;
    [SerializeField] private LayerMask enemyLayer;
    private float _rotationSpeed = 25f;
    private Transform _closestEnemy;


    public Transform TargetEnemy { get => _closestEnemy; }

    void Update()
    {
        _closestEnemy = FindClosestEnemy();   

        if (_closestEnemy != null && Vector3.Distance(transform.position, _closestEnemy.position) <= _lookAtDistance)
        {
            Vector3 direction = (_closestEnemy.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    Transform FindClosestEnemy()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _lookAtDistance, enemyLayer);

        Transform closestEnemy = null;
        float closestDistance = _lookAtDistance;

        foreach (Collider enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
}
