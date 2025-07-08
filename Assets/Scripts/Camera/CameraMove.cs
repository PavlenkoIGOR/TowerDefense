using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targetSprite; // спрайт, ограничивающий движение камеры
    public float moveSpeed = 10f;
    public float edgeThreshold; // расстояние до границы экрана для срабатывания

    private float leftLimitX;
    private float rightLimitX;

    void Start()
    {
        SpriteRenderer spriteRenderer = targetSprite.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Bounds bounds = spriteRenderer.bounds;
            leftLimitX = bounds.min.x;
            rightLimitX = bounds.max.x;
        }
        else
        {
            Debug.LogError("Нет SpriteRenderer у targetSprite");
        }
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        Vector3 mousePosition = Input.mousePosition;

        // Проверка левой границы экрана
        if (mousePosition.x <= edgeThreshold)
        {
            cameraPosition.x -= moveSpeed * Time.deltaTime;
        }
        // Проверка правой границы экрана
        else if (mousePosition.x >= Screen.width - edgeThreshold)
        {
            cameraPosition.x += moveSpeed * Time.deltaTime;
        }

        // Ограничение по границам спрайта
        float cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;

        float minCameraX = leftLimitX + cameraHalfWidth;
        float maxCameraX = rightLimitX - cameraHalfWidth;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minCameraX, maxCameraX);

        transform.position = new Vector3(cameraPosition.x, transform.position.y, transform.position.z);
    }
}
