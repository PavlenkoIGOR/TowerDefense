using UnityEngine;
using UnityEngine.Splines;

public class TriangleMoveAlongASpline : MonoBehaviour
{
    [SerializeField] private SplineContainer _path;
    public float moveSpeed = 0.2f;
    private float progress = 0f;
    Vector3 _startPos;

    void Start()
    {
        print($"{_path.Spline.Count}");
        _startPos = transform.position;
    }


    void Update()
    {
        progress += moveSpeed * Time.deltaTime / 10;
        if (progress > 1f)
        {
            progress = 1f; // остановиться на конце, или сбросить для зацикливания
        }

        Vector3 position = _path.Spline.EvaluatePosition(progress);
        transform.position = position;
    }
}
