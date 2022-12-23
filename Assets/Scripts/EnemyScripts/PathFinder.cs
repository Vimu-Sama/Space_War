using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private GetWaypoints wave_config;
    private int waypoint_index = 0;
    private List<Transform> waypnts;
    private Vector3 target_position;

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
        if (waypoint_index < waypnts.Count)
        {
            target_position = waypnts[waypoint_index].position;
            float delta = wave_config.GetMovingSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target_position, delta);
            if (transform.position == target_position)
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
