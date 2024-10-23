using UnityEngine;
using System;

public class EnemyHealth : HealthSystem
{
    public event Action OnEnemyDied;
    [SerializeField] private Enemy _enemy;
    

    private void Start()
    {
        Init(_enemy.EnemyConfig.Health);
    }

    public override void TakeDamage(float damage)
    {
        CurrentHealth = CurrentHealth - damage;
        UpdateHealthUi();
        if (CurrentHealth <= 0)
        {
            OnEnemyDied?.Invoke();
            CurrentHealth = MaxHealth;
            UpdateHealthUi();
        }

    }

}
