using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configuration", fileName = "New_Wave_Config")]
public class GetWaypoints : ScriptableObject
{
    [SerializeField] List<GameObject> enemy_prefabs;
    [SerializeField] Transform waypoint_prefabs;
    [SerializeField] float movespeed=1f;
    public float spawningTimeDifference = 0f;
    public int GetEnemyCount()
    {
        return enemy_prefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemy_prefabs[index] ;
    }

    public float GetMovingSpeed()
    {
        return movespeed;
    }
    public Transform GetIntitalWaypoint()
    {
        return waypoint_prefabs.GetChild(0);
    }

    public List<Transform> GetAllWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform p in waypoint_prefabs)
        {
            waypoints.Add(p);
        }
        return waypoints;
    }
}
