using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _rayOrigin;
    private Player _player;
    private TakeTarget _currentTarget;  
    private float _fireRate;
    private float _damage;
    private Ray _ray;
    private float maxDistance = 25f;
    

    private void Init()
    {
        _currentTarget = GetComponent<TakeTarget>();
        _player = GetComponent<Player>();
        _fireRate = _player.PlayerConfig.FireRate;
        _damage = _player.PlayerConfig.Damage;
    }
    private void Start()
    {
        Init();
        StartCoroutine(ShootingCoroutine());     
    }


    private void ShotRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.GetComponent<EnemyHealth>())
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);
            }
        }
    }


    public IEnumerator ShootingCoroutine()
    {
       
        while (true)
        {
            if (_currentTarget.TargetEnemy != null)
            {
                ShotRay();
                _particleSystem.Play();
                yield return new WaitForSeconds(_fireRate);
            }
            else
            {
                _particleSystem.Stop();
                yield return new WaitUntil(() => _currentTarget.TargetEnemy != null);
            }
            yield return null;

        }

    }

    private void Update()
    {
        _ray.origin = _rayOrigin.position;

        if (_currentTarget.TargetEnemy)
        {
            _ray.direction = _currentTarget.TargetEnemy.transform.position - transform.position;
        }
    }

}
