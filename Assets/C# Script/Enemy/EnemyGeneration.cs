using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject[] spawnPoints;

    int day;
    private Dictionary<string, float> enemySpawnTimes; // Dictionary ánh xạ tag name và thời gian sinh

    private void Start()
    {
        enemySpawnTimes = new Dictionary<string, float>
    {
        //{ "ghost", 8f },
        //{ "skeleton", 4f },
        { "goblin", 10f}
    };

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Sinh Bee
            //SpawnEnemy("ghost");

            // Chờ theo thời gian beeSpawnTime
           // yield return new WaitForSeconds(enemySpawnTimes["ghost"]);

            // Sinh Boar
            //SpawnEnemy("skeleton");

            // Chờ theo thời gian boarSpawnTime
            //yield return new WaitForSeconds(enemySpawnTimes["skeleton"]);

            // Sinh Goblin
            SpawnEnemy("goblin");

            // Chờ theo thời gian goblinSpawnTime
            yield return new WaitForSeconds(enemySpawnTimes["goblin"]);
        }
    }

    private void SpawnEnemy(string enemyTagName)
    {
        
        // Tạo một danh sách các enemy prefab có cùng tag name
        List<GameObject> enemyPrefabsWithTag = new List<GameObject>();

        // Lặp qua tất cả enemy prefabs và lọc các prefab có tag name khớp
        foreach (GameObject prefab in enemyPrefabs)
        {          
            if (prefab.tag == enemyTagName)
            {
                enemyPrefabsWithTag.Add(prefab);
            }
        }

        if (enemyPrefabsWithTag.Count == 0)
        {
            Debug.LogError("No enemy prefab found with tag: " + enemyTagName);
            return;
        }

        // Chọn ngẫu nhiên một enemy prefab từ danh sách có cùng tag name
        int randomIndex = Random.Range(0, enemyPrefabsWithTag.Count);
        GameObject enemyPrefab = enemyPrefabsWithTag[randomIndex];

        // Tìm vị trí tương ứng dựa trên tag name trong mảng spawnPoints
        GameObject spawnPoint = null;
        foreach (GameObject point in spawnPoints)
        {
            if (point.name == enemyTagName + "Point")
            {
                spawnPoint = point;
                break;
            }
        }

        if (spawnPoint == null)
        {
            Debug.LogError(enemyTagName + "Position not found in spawnPoints");
            return;
        }

        // Lấy tọa độ vị trí spawn từ thành phần transform của GameObject spawnPoint
        Vector2 spawnPosition = spawnPoint.transform.position;

        // Sinh ra enemy tại vị trí spawnPosition
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
