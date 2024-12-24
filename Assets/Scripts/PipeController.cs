using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    float time;
    public float spawnTime = 1f;

    private void Update()
    {
        if(!GameManager.Instance.isGamePlay) return;
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            time = 0f;
            Instantiate(pipePrefab,new Vector2(5,Random.Range(-2.5f,2.5f)),Quaternion.identity);
        }
      
    }
}
