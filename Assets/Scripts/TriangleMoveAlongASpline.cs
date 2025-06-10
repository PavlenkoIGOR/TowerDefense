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
        _startPos = _path.Spline.EvaluatePosition(0);
        //print($"_path.Spline.EvaluatePosition(0) {_path.Spline.EvaluatePosition(0)}");
        //print($"_startPos {_startPos}");
        transform.position = _startPos;
    }


    void Update()
    {
        //print($"transformPos {transform.position}");
        //print($"progressBefore {progress}");
        //Vector3 position = _path.Spline.EvaluatePosition(progress);
        //transform.position = position;
        //progress += moveSpeed * Time.deltaTime / 10;
        //if (progress > 1f)
        //{
        //    progress = 1f; // остановиться на конце, или сбросить для зацикливания
        //}
    }
}
