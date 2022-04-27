using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<GetWaypoints> _getWayPoints= new List<GetWaypoints>();
    [SerializeField] float spawnWavesTimeDifference = 0f;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        //do
        {
            int n = _getWayPoints.Count;
            for (int i = 0; i < n; i++)
            {
                int m = _getWayPoints[i].GetEnemyCount();
                for (int j = 0; j < m; j++)
                {
                    Instantiate(_getWayPoints[i].GetEnemyPrefab(i), transform.position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(_getWayPoints[i].spawningTimeDifference);
                }
                yield return new WaitForSeconds(spawnWavesTimeDifference);
            }

        } //while (true);
        
    }
}
