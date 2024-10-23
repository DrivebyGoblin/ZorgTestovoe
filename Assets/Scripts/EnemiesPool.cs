using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<Transform> _spawnPositions;


    private List<Enemy> _enemies;
    public List<Enemy> Enemies { get => _enemies; }

    public void CreatePool(Enemy prefab, int startCount)
    {
        _enemies = new List<Enemy>();

        for (int i = 0; i < startCount; i++)
        {
            var obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            _enemies.Add(obj);
        }
    }

    private int RandomPoision()
    {
       var index = Random.Range(0, _spawnPositions.Count);
       return index;
    }

    public Enemy GetFreeElement()
    {
        var obj = _enemies.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj)
            obj.gameObject.transform.position = _spawnPositions[RandomPoision()].position;
        else
            obj = Create();

        obj.gameObject.SetActive(true);
        return obj;
    }



    public void Release(Enemy obj)
    {
        obj.gameObject.SetActive(false);
    }

    public Enemy Create()
    {
        var obj = Instantiate(_prefab);
        _enemies.Add(obj);
        obj.gameObject.transform.position = _spawnPositions[RandomPoision()].position;
        return obj;
    }

    private void Awake()
    {
        CreatePool(_prefab, 15);
    }

    private void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GetFreeElement();
        }
    }
}
