using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/enemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] private GameObject _enemyModel;
    public GameObject EnemyModel { get => _enemyModel; }

    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get => _moveSpeed; }


    [SerializeField] private float _damage;
    public float Damage { get => _damage; }

    [SerializeField] private float _health;
    public float Health { get => _health; }


    private void OnValidate()
    {
		if (_moveSpeed < 0.01f)
		{
            _moveSpeed = 0.01f;
            Debug.LogWarning("Скорость не может быть меньше или быть равной 0");
		}

        if (_damage < 0.01f)
        {
            _damage = 0.01f;
            Debug.LogWarning("Урон не может быть меньше или быть равным 0");
        }

        if (_health < 0.01f)
        {
            _health = 0.01f;
            Debug.LogWarning("Здоровье не может быть меньше или быть равным 0");
        }
    }




}
