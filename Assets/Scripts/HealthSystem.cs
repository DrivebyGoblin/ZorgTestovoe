using UnityEngine;
using UnityEngine.UI;

public abstract class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private Image _healthBarUi;

    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; protected set; }

    public void Init(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
    }


    public void UpdateHealthUi()
    {
        if (_healthBarUi != null)
        {
            _healthBarUi.fillAmount = GetHealthPercentage();
        }
    }

    public float GetHealthPercentage()
    {
        return CurrentHealth / MaxHealth;
    }

    public abstract void TakeDamage(float damage);
}
