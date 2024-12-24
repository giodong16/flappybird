using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FlappyBirdControl flappyBirdControl;
    public GameObject birdPrefab;
    public bool isGamePlay;
    private void Awake()
    {
        Instance = this;
        isGamePlay = false;
    }
    public void ClearAllPipes()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        if(pipes == null || pipes.Length == 0 ) { return; }
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
    }
}
