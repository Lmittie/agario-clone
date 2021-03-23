using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarioEnemyController : AgarioBaseController
{
    private Vector3 vectorScale;
    public Camera playerCamera;
    private float cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        mass = transform.localScale.x;
        speed = 2.0f; // ???
    }

    // Update is called once per frame
    void Update()
    {
        vectorScale.Set((mass), (mass), 1);
        transform.localScale = vectorScale;
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        OnPlayerEnter(col);
    }

    protected override void OnFoodBiggerThenObject()
    {
        speed = 0;
        // set active back to menu button
    }

    private void OnPlayerEnter(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            if (col.gameObject.transform.localScale.x > gameObject.transform.localScale.x)
            {
                // ...
            }
        }
    }
}
