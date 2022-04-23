using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] GetWaypoints wave_config;
    int waypoint_index=0 ;
    List<Transform> waypnts;

    private void Start()
    {
        waypnts = wave_config.GetAllWaypoints();
        transform.position = waypnts[waypoint_index].position;
    }

    private void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypoint_index < waypnts.Count)
        {
            Vector3 target_position= waypnts[waypoint_index].position;
            float delta = wave_config.GetMovingSpeed() * Time.deltaTime;
            transform.position =  Vector2.MoveTowards(transform.position, target_position, delta);
            if(transform.position == target_position)
            {
                waypoint_index++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
