using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;   //화살 이동 속도
    public float damage = 1f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 135);   //받아온 화살 이미지가 우측 하단을 향하고 있어서 회전으로 조정함
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(gameObject, 1f);    
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
