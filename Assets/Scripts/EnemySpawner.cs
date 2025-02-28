using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemies;   //"Enemy" 오브젝트를 받는 오브젝트
    

    [SerializeField]
    private float spawnInterval = 0f;   //적 생성 주기 설정
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
        if (Random.value < 0.5f) randX = -1.3f; //적이 우측에서 나올지 좌측에서 나올지 무작위 설정
        else randX = 1.2f;
        Vector3 spawnPos = new Vector3(randX, transform.position.y, transform.position.z);
        GameObject enemyObject = Instantiate(enemies, spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
    }
} 