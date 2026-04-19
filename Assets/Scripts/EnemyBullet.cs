using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;

    void Start()
    {
        // ����� ������ � ������� ������ ��������
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
        Destroy(gameObject, 5f); // ������� ����� 5 ���
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        // ���������, ������ �� � ������
        StatusManager playerStatus = hit.GetComponent<StatusManager>();
        if (playerStatus != null)
        {
            playerStatus.TakeDamage(damage); // ���� ����� �� StatusManager
            Destroy(gameObject);
        }
    }
}````