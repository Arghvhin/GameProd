using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string level;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("fuck me");
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
