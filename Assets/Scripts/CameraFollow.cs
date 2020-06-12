using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [SerializeField] private float maxLeft;
    [SerializeField] private float maxRight;
    [SerializeField] private float maxTop;
    [SerializeField] private float maxBottom;

    void Start()
    {
        int width = 800; // or something else
        int height = 600; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }

    void Update()
    {
        if(Lifes.isDead == false)
        {
            if (player.position.x > maxLeft && player.position.x < maxRight && player.position.y < maxTop && player.position.y > maxBottom)
            {
                transform.position = player.position + offset;
            }
            else if (player.position.x < maxLeft)
            {
                transform.position = new Vector3(maxLeft, player.transform.position.y, -30f);
            }
            else if (player.position.x > maxRight)
            {
                transform.position = new Vector3(maxRight, player.transform.position.y, -30f);
            }
            else if (player.position.y > maxTop)
            {
                transform.position = new Vector3(player.transform.position.x, maxTop, -30f);
            }
            else if (player.position.y < maxBottom)
            {
                transform.position = new Vector3(player.transform.position.x, maxBottom, -30f);
            }
        }
        
    }
}
