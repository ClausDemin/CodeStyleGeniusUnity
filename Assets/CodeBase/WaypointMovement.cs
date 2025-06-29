using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _movementSpeed;

    private Transform[] _waypoints;

    private void Start()
    {
        ExtractWaypointsFromPath();

        StartCoroutine(Move());
    }

    private void ExtractWaypointsFromPath()
    {
        _waypoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _waypoints[i] = _path.GetChild(i).GetComponent<Transform>();
        }
    }

    private IEnumerator Move()
    {
        if (_path != null && _waypoints.Length > 0)
        {
            foreach (Vector3 waypoint in GetNextWaypoint())
            {
                while (IsTargetReached(waypoint) == false)
                {
                    LookAtTarget(waypoint);

                    transform.position = Vector3.MoveTowards(transform.position, waypoint, _movementSpeed * Time.deltaTime);

                    yield return null;
                }
            }
        }
    }

    private IEnumerable<Vector3> GetNextWaypoint()
    {
        int pathLength = _waypoints.Length;
        int currentWaypoint = 0;

        while (isActiveAndEnabled)
        {
            yield return _waypoints[currentWaypoint % pathLength].position;

            currentWaypoint++;
        }
    }

    private bool IsTargetReached(Vector3 target)
    {
        return transform.position == target;
    }

    private void LookAtTarget(Vector3 target)
    {
        transform.forward = target - transform.position;
    }
}