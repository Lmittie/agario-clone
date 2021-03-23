using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgarioBaseController : MonoBehaviour
{
    public float mass;
    public float speed;
    public float delta;
    const float MASS_DELTA = 2.5f;

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Food"))
        {
            if (col.gameObject.transform.localScale.x > gameObject.transform.localScale.x)
            {
                OnFoodBiggerThenObject();
            }
            else
            {
                mass += col.gameObject.transform.localScale.x;
                speed = speed > 0.2 ? speed - 0.0025f : speed;
                Vector2 randomVector = new Vector2(
                        Random.Range(-99.5f, 99.5f),
                        Random.Range(-99.5f, 99.5f)
                    );
                col.gameObject.transform.position = randomVector;
            }
        }
    }

    protected abstract void OnFoodBiggerThenObject();
}
