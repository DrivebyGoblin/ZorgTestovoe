using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private Enemy _enemy;
    private float _damage;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _damage = _enemy.EnemyConfig.Damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_damage);
        }
    }

}
