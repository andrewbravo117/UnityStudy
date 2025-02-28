using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;   //ȭ�� �̵� �ӵ�
    public float damage = 1f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 135);   //�޾ƿ� ȭ�� �̹����� ���� �ϴ��� ���ϰ� �־ ȸ������ ������
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(gameObject, 1f);    
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
