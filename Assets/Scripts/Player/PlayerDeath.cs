using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{ 
    public static event Action onEnemyStoped;
    [SerializeField] private GameObject _textGameOver;


    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += Dead;      
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= Dead;
    }

    public void Dead()
    {
        onEnemyStoped?.Invoke();
        _textGameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
