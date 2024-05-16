using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    Transform rb;

    public GameObject enemy;
    public GameObject bossGolem;
    public GameObject bossDeer;
    //private GameObject enem = null;
    public int spawnPos_x, spawnPos_y, spawnCount;

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Transform>();
        rb.transform.position = new Vector3(spawnPos_x, spawnPos_y, 5);
        setEnemySpawn();
    }

    public void setEnemySpawn()
    {
        for (int i = 1; i < spawnCount + 1; i++)
        {
            Instantiate(enemy, new Vector3(spawnPos_x + i * 5, spawnPos_y - 1, 0), Quaternion.identity);
        }
    }

    public void setBossGolemSpawn()
    {
        Instantiate(bossGolem, new Vector3(spawnPos_x * 5, spawnPos_y - 0.5f, 0), Quaternion.identity);
    }

    public void setBossDeerSpawn()
    {
        Instantiate(bossDeer, new Vector3(spawnPos_x * 5, spawnPos_y - 0.3f, 0), Quaternion.identity);
    }
}
