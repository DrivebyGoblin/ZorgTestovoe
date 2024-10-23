using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField]
    private float _health;
    public float Health { get => _health; }


    [SerializeField]
    private float _fireRate;
    public float FireRate { get => _fireRate; }


    [SerializeField]
    private float _damage;
    public float Damage { get => _damage; }



    private void OnValidate()
    {
        if (_health < 0.01f)
        {
            _health = 0.01f;
            Debug.LogWarning("здоровье не может быть меньше или равным 0");
        }
        if (_fireRate < 0)
        {
            _fireRate = 0;
            Debug.LogWarning("Скорость стрельбы не может быть отрицательной");
        }

        if (_damage < 0.01f)
        {
            _damage = 0.01f;
            Debug.LogWarning("Урон не может быть меньше или равным 0");
        }

    }
}
