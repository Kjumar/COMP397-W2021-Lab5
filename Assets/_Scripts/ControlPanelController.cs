using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour
{
    public RectTransform rectTransform;

    public Vector2 offscreenPosition;
    public Vector2 onscreenPosition;

    [Range(0.1f, 10f)] public float speed = 1f;
    public float timer = 0f;

    public bool isOnScreen = false;

    public CameraController playerCamera;

    public Pauseable pauseable;

    // Start is called before the first frame update
    void Start()
    {
        pauseable = FindObjectOfType<Pauseable>();

        rectTransform = GetComponent<RectTransform>();

        playerCamera = FindObjectOfType<CameraController>();

        rectTransform.anchoredPosition = offscreenPosition;

        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isOnScreen = !isOnScreen;
            timer = 0f;

            if (isOnScreen)
            {
                Cursor.lockState = CursorLockMode.None;
                playerCamera.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                playerCamera.enabled = true;
            }
        }

        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }

    private void MoveControlPanelDown()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(offscreenPosition, onscreenPosition, timer);

        if (timer < 1f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    private void MoveControlPanelUp()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(onscreenPosition, offscreenPosition, timer);

        if (timer < 1f)
        {
            timer += Time.deltaTime * speed;
        }

        if (pauseable.isGamePaused)
        {
            pauseable.TogglePause();
        }
    }
}
