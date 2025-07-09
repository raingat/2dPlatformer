using UnityEngine;

public class PatrolZone : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public float GetRandomPositionX()
    {
        int firstIndex = 0;

        float coordinateX = _points[Random.Range(firstIndex, _points.Length)].position.x;

        return coordinateX;
    }
}
