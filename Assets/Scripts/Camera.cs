using System;
using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    private Transform player;
    private int lastX;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);
    }

    public void FindPlayer(bool playerFaceLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerFaceLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            faceLeft = currentX < lastX;
            lastX = currentX;

            Vector3 target = faceLeft
                ? new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z)
                : new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
        }
    }
}
