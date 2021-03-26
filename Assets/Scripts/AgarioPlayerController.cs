using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AgarioPlayerController : AgarioBaseController
{
    public Camera playerCamera;
    public Text playerName;
    public Text playerScore;
    private Vector2 _mousePosition;
    private float _cameraSize;
    private const float _speed = 1.3f;
    private string _playerName;
    private int _playerScore;

    // Start is called before the first frame update
    void Start()
    {
        _cameraSize = 5;
        playerCamera.orthographicSize = _cameraSize;

        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().PlayMusic();

        _playerName = PlayerPrefs.GetString("playerName", "agar");
        playerName.text = "Name: " + _playerName;
        _playerScore = 0;
        playerScore.text = "Score: " + _playerScore;

        Color color;
        if (ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("ColorKey"), out color))
            gameObject.GetComponent<SpriteRenderer>().color = color;
        else
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        _mousePosition -= (Vector2)transform.position;
        transform.Translate(_mousePosition * Time.deltaTime * _speed / mass);
        Vector3 vectorScale = new Vector3(mass, mass, 1);
        transform.localScale = vectorScale;
        SmoothCamera();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        _cameraSize += 0.15f * col.transform.localScale.x;
        _playerScore = Mathf.CeilToInt(mass);
        playerScore.text = "Score: " + _playerScore;
    }

    private void SmoothCamera()
    {
        if (playerCamera.orthographicSize > _cameraSize)
        {
            if (playerCamera.orthographicSize + 1 > _cameraSize)
                playerCamera.orthographicSize = _cameraSize;
            else
                playerCamera.orthographicSize += 0.001f;
        }
        else if (playerCamera.orthographicSize < _cameraSize)
        {
            if (playerCamera.orthographicSize - 1 < _cameraSize)
                playerCamera.orthographicSize = _cameraSize;
            else
                playerCamera.orthographicSize -= 0.001f;
        }
    }

    protected override void OnEnemyBigger(Collider2D col)
    {
        ChangeObjectScale(col.gameObject);
        transform.DetachChildren();
        gameObject.SetActive(false);
        Invoke("BackToMainMenu", 4f);
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
