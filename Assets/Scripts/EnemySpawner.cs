using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GetWaypoints _getWayPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        int n = _getWayPoints.GetEnemyCount();
        for(int i=0;i<n;i++)
        {
            Instantiate(_getWayPoints.GetEnemyPrefab(i), transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(_getWayPoints.spawningTimeDifference) ;
        }
    }
}
