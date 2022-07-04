using UnityEngine;
using Random = UnityEngine.Random;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out var pipe))
            {
                _elapsedTime = 0f;
                var spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                var spawnPoint = transform.position;
                spawnPoint.y = spawnPositionY;
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                DisableObjectAbroadScreen();
            }
        }
    }
}