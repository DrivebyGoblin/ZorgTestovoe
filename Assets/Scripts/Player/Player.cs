using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    public PlayerConfig PlayerConfig { get => _playerConfig; }

    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
