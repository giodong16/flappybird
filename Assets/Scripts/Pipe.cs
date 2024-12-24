using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2.5f;

    private void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }
}
