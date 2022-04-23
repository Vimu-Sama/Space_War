using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Configuration", fileName = "New_Wave_Config")]
public class GetWaypoints : ScriptableObject
{
    
    [SerializeField] Transform waypoint_prefabs;
    [SerializeField] float movespeed=1f;


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
