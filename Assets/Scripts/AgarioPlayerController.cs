using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarioPlayerController : AgarioBaseController
{
    private Vector2 mousePosition;
    private Vector3 vectorScale;
    public Camera playerCamera;
    private float cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        mass = 1.0f;
        speed = 2.0f;
        cameraSize = 5;
        playerCamera.orthographicSize = cameraSize;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition -= (Vector2)transform.position;
        transform.Translate(mousePosition * speed * Time.deltaTime);
        vectorScale.Set((mass), (mass), 1);
        transform.localScale = vectorScale;
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        float prevMass = mass;
        base.OnTriggerEnter2D(col);
        OnEnemyEnter(col);
        cameraSize += 0.002f * (mass - prevMass);
        playerCamera.orthographicSize = cameraSize;
    }

    protected override void OnFoodBiggerThenObject()
    {
        speed = 0;
        // set active back to menu button
    }

    private void OnEnemyEnter(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            if (col.gameObject.transform.localScale.x > gameObject.transform.localScale.x)
            {
                speed = 0;
                // set active back to menu button
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
                col.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
