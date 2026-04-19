using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Start()
    {
        // ���� ����� ������ ����� ����� ���������
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
        // ������� ���� ����� 3 �������, ����� �� �������� ������
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        EnemyController enemy = hit.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}