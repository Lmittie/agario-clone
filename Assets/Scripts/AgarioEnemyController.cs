using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarioEnemyController : AgarioBaseController
{
    private FindClosest findClosest;
    private List<GameObject> enemies;
    private GameObject[] food;
    private Transform target;
    private float speed = 5f;
 
    // Start is called before the first frame update
    private void Awake()
    {
        findClosest = GetComponentInChildren<FindClosest>();
    }
    void Start()
    {
        mass = transform.localScale.x;

        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        // enemies = new List<GameObject>(enemiesArray);
        // enemies.Add(GameObject.FindGameObjectWithTag("Player"));
        // target = GetClosestEnemy();

        food = GameObject.FindGameObjectsWithTag("Food");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorScale = new Vector3(mass, mass, 1);
        transform.localScale = vectorScale;
        
        target = findClosest.GetClosest();
        if (target == null)
        {
            return;
        }
        // enemies.RemoveAll(item => item == null);
        // target = GetClosestEnemy();

        float step = speed * Time.deltaTime / mass;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    protected override void OnBiggerThenObject(Collider2D col)
    {
        if (gameObject.tag.Equals("Enemy"))
            mass = 1f;
        GenerateObjInAnotherPlace(gameObject);
    }

    private Transform GetClosestEnemy()
    {
        Transform tMin = FindMinTransform(enemies.ToArray());
        return tMin == null ? EatFood() : tMin;
    }

    private Transform EatFood()
    {
        return FindMinTransform(food);
    }

    private Transform FindMinTransform(GameObject[] objects)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject obj in objects)
        {
            float dist = Vector3.Distance(obj.transform.position, currentPos);
            if (dist < minDist && obj.transform.localScale.x < transform.localScale.x)
            {
                tMin = obj.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

}
