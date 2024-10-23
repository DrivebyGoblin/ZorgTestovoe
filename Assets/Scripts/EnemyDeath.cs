using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;
    private void OnEnable()
    {
        _health.OnEnemyDied += Dead;
    }

    private void OnDisable()
    {
        _health.OnEnemyDied -= Dead;
    }

    public void Dead()
    {
        this.gameObject.SetActive(false);
    }
}
