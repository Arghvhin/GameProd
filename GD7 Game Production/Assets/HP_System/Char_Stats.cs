using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Char_Stats : MonoBehaviour
{
    public GameObject playerGameObject;
    private Vector3 BeginningPosition;
    public int maxLives = 3;
    [Header("Current Stats")]
    public int currentLives;
    public Image heartImage1;
    public Image heartImage2;
    public void TakeDamage()
    {
       
        currentLives--;
        // Hide the heart image.
        if (currentLives == 1)
        {
            heartImage2.enabled = false; 
        }
        if (currentLives == 2)
        {
            heartImage1.enabled = false; 
        }
        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Lava Take damage
        if (collision.gameObject.CompareTag("Lava"))
        {
            TeleportToBeginningPosition();
            TakeDamage();
        }
        //Enemy Take damage
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TeleportToBeginningPosition();
            ResetEnemyPosition();
            TakeDamage();
        }
    }
    //Teleports player to the start of the level
    private void TeleportToBeginningPosition()
    {
        transform.position = BeginningPosition;
    }
   //Reset enemy position
    private void ResetEnemyPosition()
    {
        
    }
    void Start()
    {
        currentLives = maxLives;
        BeginningPosition = transform.position;
    }
}