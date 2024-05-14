using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Char_Stats : MonoBehaviour
{
    public GameObject playerGameObject;
    public Vector3 BeginningPosition;
    public int maxLives = 3;
    [Header("Current Stats")]
    public int currentLives;
    public Image heartImage1;
    public Image heartImage2;
    public GameObject[] enemies;
    public Vector3[] enemiesStart;
    public void TakeDamage()
    {
       
        --currentLives;
        // Hide the heart image.
        if (currentLives == 2)
        {
            heartImage1.enabled = false;
            
        }
        else if (currentLives == 1)
        {
            heartImage2.enabled = false; 
        }
        else if (currentLives == 0)
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
    }
    //Teleports player to the start of the level
    private void TeleportToBeginningPosition()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false; // Disable the controller temporarily
            controller.transform.position = new Vector3(BeginningPosition.x, BeginningPosition.y, BeginningPosition.z);
            controller.enabled = true; // Re-enable the controller
        }
        else
        {
            Debug.LogError("CharacterController not found on the player GameObject.");
        }
        print("a");
        gameObject.transform.position = BeginningPosition;
    }
   //Reset enemy position
    private void ResetEnemyPosition()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = enemiesStart[i];
        }
    }
    void Start()
    {
        currentLives = maxLives;
        BeginningPosition = transform.position;

        enemiesStart = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++) {
            enemiesStart[i] = enemies[i].transform.position;
        }

    }
    private void Update()
    {
        Debug.DrawRay(BeginningPosition, Vector3.up * 10f, Color.green, 10f);
    }
}