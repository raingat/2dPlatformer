using UnityEngine;

public class FirstAidKitSpawner : MonoBehaviour
{
    [SerializeField] private FirstAidKit _prefab;

    [SerializeField] private Transform[] _points;

    [SerializeField] private int _count;

    private int _firstIndex = 0;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _count; i++)
        {
            Transform point = _points[Random.Range(_firstIndex, _points.Length)];

            Instantiate(_prefab, point.transform.position, Quaternion.identity);
        }
    }
}
