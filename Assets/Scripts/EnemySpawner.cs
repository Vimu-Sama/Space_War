using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GetWaypoints> _getWayPoints= new List<GetWaypoints>();
    [SerializeField] int maxWaveCount=1;
    [SerializeField] float spawnWavesTimeDifference = 0f;
    int prevEnemy = -1;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            int n = _getWayPoints.Count;
            
            for (int i = 0; i < n; i++)
            {
                int p = 0;
                while(prevEnemy==p)
                {
                    p = Random.Range(0, n);
                }
                prevEnemy = p;
                int m = _getWayPoints[p].GetEnemyCount();
                for (int j = 0; j < m; j++)
                {
                    Instantiate(_getWayPoints[p].GetEnemyPrefab(i), transform.position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(_getWayPoints[p].spawningTimeDifference);
                }
                yield return new WaitForSeconds(Random.Range(3,spawnWavesTimeDifference));
            }

        } while (true);
        
    }
}
