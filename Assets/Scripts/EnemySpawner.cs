using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemies;   //"Enemy" ������Ʈ�� �޴� ������Ʈ
    

    [SerializeField]
    private float spawnInterval = 0f;   //�� ���� �ֱ� ����
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine() {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy() {
        float randX = 0f;
        if (Random.value < 0.5f) randX = -1.3f; //���� �������� ������ �������� ������ ������ ����
        else randX = 1.2f;
        Vector3 spawnPos = new Vector3(randX, transform.position.y, transform.position.z);
        GameObject enemyObject = Instantiate(enemies, spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
    }
} 