using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;    //�÷��̾� �̵��ӵ�

    [SerializeField]
    private GameObject weapon;  //������ "Arrow"�� �ް� �ִ� ������Ʈ

    [SerializeField]
    private Transform Bow;  //"Player" ������Ʈ�� �ڽ� ������Ʈ�� �پ��ִ� "Bow"�� �ް��ִ� ������Ʈ (���������� "Arrow"�� �����Ǵ� ��ġ)

    [SerializeField]
    private float shootInterval = 0.5f; //���ݼӵ�
    private float lastShotTime = 0f;    //���� �ð����� �ش� ���� ������ ���� ȭ���� �������� �󸶳� �ð��� �������� Ȯ��

    [SerializeField]
    public float hp = 10f;
    public TextMeshPro playerHp;

    private void Start()
    {
        UpdateUI();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        Shoot();
    }

    void Shoot() {
        if (Time.time - lastShotTime > shootInterval){
            Instantiate(weapon, Bow.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy"){
            Enemy enemy = other.transform.GetComponent<Enemy>();
            hp -= enemy.hp;
            if (hp <= 0f) {
                Debug.Log("Game Over");
                Destroy(gameObject);
            }

            UpdateUI();
        }
    }

    private void UpdateUI() {
        if (playerHp != null) playerHp.text = hp.ToString();
    }
}