using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgarioPlayerController : AgarioBaseController
{
    private Vector2 mousePosition;
    public Camera playerCamera;
    private float cameraSize;
    private float speed = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        cameraSize = 5;
        playerCamera.orthographicSize = cameraSize;

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().PlayMusic();

        Color color;
        ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("ColorKey"), out color);
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition -= (Vector2)transform.position;
        transform.Translate(mousePosition * Time.deltaTime * speed / mass);
        Vector3 vectorScale = new Vector3(mass, mass, 1);
        transform.localScale = vectorScale;
        SmoothCamera();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        cameraSize += 0.15f * col.transform.localScale.x;
    }

    private void SmoothCamera()
    {
        if (playerCamera.orthographicSize > cameraSize) {
            if (playerCamera.orthographicSize + 1 > cameraSize)
                playerCamera.orthographicSize = cameraSize;
            else
                playerCamera.orthographicSize += 0.001f;
        } else if (playerCamera.orthographicSize < cameraSize) {
            if (playerCamera.orthographicSize - 1 < cameraSize)
                playerCamera.orthographicSize = cameraSize;
            else
                playerCamera.orthographicSize -= 0.001f;
        }
    }

    protected override void OnBiggerThenObject(Collider2D col)
    {
        ChangeObjectScale(col.gameObject);
        transform.DetachChildren();
        gameObject.SetActive(false);
        Invoke("BackToMainMenu", 4f);
    }

    private void ChangeObjectScale(GameObject obj)
    {
        obj.transform.localScale = new Vector3(
                    obj.transform.localScale.x + transform.localScale.x * MULT,
                    obj.transform.localScale.y + transform.localScale.y * MULT,
                    obj.transform.localScale.z
                );
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
