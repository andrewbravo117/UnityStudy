using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;    //플레이어 이동속도

    [SerializeField]
    private GameObject weapon;  //무기인 "Arrow"를 받고 있는 오브젝트

    [SerializeField]
    private Transform Bow;  //"Player" 오브젝트의 자식 오브젝트로 붙어있는 "Bow"를 받고있는 오브젝트 (실질적으로 "Arrow"가 생성되는 위치)

    [SerializeField]
    private float shootInterval = 0.5f; //공격속도
    private float lastShotTime = 0f;    //현재 시간에서 해당 변수 뺄셈을 통해 화살을 쏜지부터 얼마나 시간이 지났는지 확인

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