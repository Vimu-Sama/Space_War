using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : GenericSingleton<EnemySpawner>
{

    [SerializeField] private List<GetWaypoints> _getWayPoints = new List<GetWaypoints>();
    [SerializeField] private int maxWaveCount = 1;
    [SerializeField] private float spawnWavesTimeDifference = 0f;
    private int prevEnemy = -1;
    private int currWayPointsCount;
    int tempInt, secondTempInt;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        do
        {
            currWayPointsCount = _getWayPoints.Count;

            for (int i = 0; i < currWayPointsCount; i++)
            {
                tempInt = 0;
                while (prevEnemy == tempInt)
                {
                    tempInt = Random.Range(0, currWayPointsCount);
                }
                prevEnemy = tempInt;
                secondTempInt = _getWayPoints[tempInt].GetEnemyCount();
                for (int j = 0; j < secondTempInt; j++)
                {
                    Instantiate(_getWayPoints[tempInt].GetEnemyPrefab(i), transform.position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(_getWayPoints[tempInt].spawningTimeDifference);
                }
                yield return new WaitForSeconds(Random.Range(3, spawnWavesTimeDifference));
            }

        } while (true);

    }
}
