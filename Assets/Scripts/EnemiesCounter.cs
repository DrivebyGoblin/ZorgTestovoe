using System.Collections;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    private EnemiesPool _pool;

    private int _needToBeActive = 5;
    private void Start()
    {
        _pool = GetComponent<EnemiesPool>();
        StartCoroutine(Spawner());
    }

    public void ChekActiveEnemies()
    {
        int activeEnemies = 0;
        for (int i = 0; i < _pool.Enemies.Count; i++)
        {
            if (_pool.Enemies[i].isActiveAndEnabled)
            {
                activeEnemies = activeEnemies + 1;
            }
        }

        if (activeEnemies < _needToBeActive)
        {
            _pool.GetFreeElement();
        }
    }

    private IEnumerator Spawner()
    {
        while (true)
        {          
            _pool.GetFreeElement();
            yield return new WaitForSeconds(5f);
        }
        
    }


    void FixedUpdate()
    {
        ChekActiveEnemies();        
    }
}
