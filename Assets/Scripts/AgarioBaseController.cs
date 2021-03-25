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
                OnBiggerThenObject(col);
            }
            else
            {
                mass += col.gameObject.transform.localScale.x * MULT;
                if (col.gameObject.tag.Equals("Enemy"))
                    col.gameObject.transform.localScale = Vector3.one;
                GenerateObjInAnotherPlace(col.gameObject);
            }
        }
    }

    protected abstract void OnBiggerThenObject(Collider2D col);

    protected void GenerateObjInAnotherPlace(GameObject obj)
    {
        float x = obj.transform.localScale.x;
        Vector2 randomVector = new Vector2(
            Random.Range((200.0f - x) * -1.0f, (200.0f - x)),
            Random.Range((200.0f - x) * -1.0f, (200.0f - x))
        );
        obj.transform.position = randomVector;
    }
}
