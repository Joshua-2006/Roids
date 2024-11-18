using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        screenBounds = new Vector2(mainCamera.aspect * mainCamera.orthographicSize, mainCamera.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        WrapAround();
    }
    void WrapAround()
    {
        Vector3 position = transform.position;

    
        if (position.x > screenBounds.x)
            position.x = -screenBounds.x;
        else if (position.x < -screenBounds.x)
            position.x = screenBounds.x;

        if (position.y > screenBounds.y)
            position.y = -screenBounds.y;
        else if (position.y < -screenBounds.y)
            position.y = screenBounds.y;

        transform.position = position;
    }
}
