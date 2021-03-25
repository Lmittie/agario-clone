using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    public List<Transform> _enemies = new List<Transform>();
    public List<Transform> _foods = new List<Transform>();

    public Transform GetClosest()
    {
        Transform closest = GetClosestTransform(_enemies);
        return closest == null ? GetClosestTransform(_foods) : closest;
    }

    private Transform GetClosestTransform(List<Transform> objs)
    {
        Transform closest = null;
    
        float minDist = Mathf.Infinity;

        foreach(Transform obj in objs)
        {
            float dist = Vector3.Distance(obj.position, transform.parent.position);
            if (dist < minDist && obj.localScale.x < transform.parent.localScale.x)
            {
                closest = obj.transform;
                minDist = dist;
            }
        }

        return closest;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == transform.parent.gameObject)
        {
            return; 
        }

        if (col.tag.Equals("Enemy") || col.tag.Equals("Player"))
            _enemies.Add(col.gameObject.transform);
        else if (col.tag.Equals("Food"))
            _foods.Add(col.gameObject.transform);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == transform.parent.gameObject)
        {
            return; 
        }

        if ((col.tag.Equals("Enemy") || col.tag.Equals("Player")) && _enemies.Contains(col.gameObject.transform))
            _enemies.Remove(col.gameObject.transform);
        else if (col.tag.Equals("Food") && _foods.Contains(col.gameObject.transform))
            _foods.Remove(col.gameObject.transform);
    }

    

}
