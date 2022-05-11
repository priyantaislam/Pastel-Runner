using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint_follow : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int curr_index = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(waypoints[curr_index].transform.position, transform.position) < 0.1f)
        {
            curr_index++;
            if(curr_index >= waypoints.Length)
            {
                curr_index = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[curr_index].transform.position,Time.deltaTime * speed);
    }
}
