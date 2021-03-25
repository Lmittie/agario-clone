using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnerScript : MonoBehaviour
{
    public GameObject food;
    private Vector2 randomVector;
    private Vector3 scale;

    void Awake()
    {
        for (int i = 0; i < 4000; ++i)
        {        
            scale.Set(0.25f, 0.25f, 1.0f);
            randomVector.Set(
                    Random.Range((200.0f - scale.x) * -1.0f, (200.0f - scale.x)),
                    Random.Range((200.0f - scale.x) * -1.0f, (200.0f - scale.x))
                );
            Instantiate(food, randomVector, Quaternion.identity);
            food.transform.localScale = scale;
        }
        for (int i = 0; i < 500; ++i)
        {
            float randomScale = Random.Range(0.25f, 2.0f);

            randomVector.Set(
                    Random.Range((200.0f - randomScale) * -1.0f, (200.0f - randomScale)),
                    Random.Range((200.0f - randomScale) * -1.0f, (200.0f - randomScale))
                );
            Instantiate(food, randomVector, Quaternion.identity);

            scale.Set(randomScale, randomScale, 1.0f);
            food.transform.localScale = scale;
        }
    }
}
