using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgarioBaseController : MonoBehaviour
{
    [SerializeField]
    public float mass;
    protected const float MULT = 0.1f;
    
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Food") || col.gameObject.tag.Equals("Enemy"))
        {
            if (col.gameObject.transform.localScale.x > gameObject.transform.localScale.x)
            {
                OnEnemyBigger(col);
            }
            else
            {
                OnObjectBigger(col);
            }
        }
    }

    protected abstract void OnEnemyBigger(Collider2D col);

    protected virtual void OnObjectBigger(Collider2D col)
    {
        mass += col.gameObject.transform.localScale.x * MULT;
        GenerateObjInAnotherPlace(col.gameObject);
    }

    protected void GenerateObjInAnotherPlace(GameObject obj)
    {
        float x = obj.transform.localScale.x;
        Vector2 randomVector = new Vector2(
            Random.Range((200.0f - x) * -1.0f, (200.0f - x)),
            Random.Range((200.0f - x) * -1.0f, (200.0f - x))
        );
        obj.transform.position = randomVector;
    }
    protected void ChangeObjectScale(GameObject obj)
    {
        obj.transform.localScale = new Vector3(
                    obj.transform.localScale.x + mass * MULT,
                    obj.transform.localScale.y + mass * MULT,
                    obj.transform.localScale.z
                );
    }
}
