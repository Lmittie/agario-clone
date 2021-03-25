using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemy;
    private Vector2 randomVector;
    private Vector3 scale;

    void Awake()
    {
        for (int i = 0; i < 100; ++i)
        {
            float randomScale = Random.Range(1.0f, 5.0f);

            randomVector.Set(
                    Random.Range((200.0f - randomScale) * -1.0f, (200.0f - randomScale)),
                    Random.Range((200.0f - randomScale) * -1.0f, (200.0f - randomScale))
                );
            Instantiate(enemy, randomVector, Quaternion.identity);

            scale.Set(randomScale, randomScale, 1.0f);
            enemy.transform.localScale = scale;
        }
    }
}
