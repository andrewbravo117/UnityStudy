using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;  //�� �̵��ӵ�

    private float minY = -7f;    //���� ȭ�� �۱��� �̵��� ��� ������ ��ġ

    public float hp = 3f;

    private bool isHit = false;
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) return;

        if (other.gameObject.tag == "Weapon") { 
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            Destroy(other.gameObject);
            isHit = true;

            hp -= weapon.damage;

            if (hp <= 0) { 
                Destroy (gameObject);
            }
            ;
            isHit = false;
        }
    }
}
