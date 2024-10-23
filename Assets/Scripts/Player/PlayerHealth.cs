using System;

public class PlayerHealth : HealthSystem
{
    public static event Action OnPlayerDied;
    private Player _player;

    public override void TakeDamage(float damage)
    {
        CurrentHealth = CurrentHealth - damage;
        UpdateHealthUi();
        if (CurrentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
        }       
    }

    private void Start()
    {
        _player = GetComponent<Player>();
        Init(_player.PlayerConfig.Health);
    }
}
