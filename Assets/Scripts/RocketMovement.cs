using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed = 5f; // Скорость ракеты
    private Rigidbody2D rb; // Ссылка на Rigidbody2D
    private Vector2 moveDirection; // Текущее направление движения

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection(); // Устанавливаем начальное случайное направление
    }

    void FixedUpdate()
    {
        // Устанавливаем скорость ракеты
        rb.velocity = moveDirection * speed;

        // Ограничение координат (страховка от выхода за пределы экрана)
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -10f, 10f); // Заменить границы на реальные
        position.y = Mathf.Clamp(position.y, -5f, 5f);
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем столкновение с границей
        if (other.CompareTag("Boundary"))
        {
            Debug.Log("Boundary hit! Changing direction.");
            SetRandomDirection(); // Меняем направление при столкновении
        }
    }

    void SetRandomDirection()
    {
        // Генерация случайного направления
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;

        Debug.Log($"New Direction: {moveDirection}");
    }
}
