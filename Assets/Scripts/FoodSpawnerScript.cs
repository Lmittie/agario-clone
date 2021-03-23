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
        for (int i = 0; i < 1000; ++i)
        {
            float randomScale = Random.Range(0.25f, 2.0f);

            randomVector.Set(
                    Random.Range((100.0f - randomScale) * -1.0f, (100.0f - randomScale)),
                    Random.Range((100.0f - randomScale) * -1.0f, (100.0f - randomScale))
                );
            Instantiate(food, randomVector, Quaternion.identity);

            scale.Set(randomScale, randomScale, 1.0f);
            food.transform.localScale = scale;
        }
    }
}
