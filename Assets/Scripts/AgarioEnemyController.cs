using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarioEnemyController : AgarioBaseController
{
    private FindClosest findClosest;
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

        float step = speed * Time.deltaTime / mass;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    protected override void OnEnemyBigger(Collider2D col)
    {
        mass = 1f;
        if (col.tag.Equals("Food"))
        {
            ChangeObjectScale(col.gameObject);
            GenerateObjInAnotherPlace(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.tag.Equals("Player"))
        {
            if (col.transform.localScale.x < mass)
                mass += col.gameObject.transform.localScale.x * MULT;
        }
    }

}
