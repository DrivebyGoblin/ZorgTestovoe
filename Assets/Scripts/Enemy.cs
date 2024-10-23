using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyConfig _enemyConfig;
    public EnemyConfig EnemyConfig { get => _enemyConfig; }


    private void Awake()
    {
        if (_enemyConfig != null && _enemyConfig.EnemyModel != null)
        {
            Instantiate(_enemyConfig.EnemyModel, transform.position, Quaternion.identity, transform);
        }
    }

}
