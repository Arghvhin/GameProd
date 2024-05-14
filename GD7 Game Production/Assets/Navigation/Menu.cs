using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Define textures for button backgrounds
    public Texture2D startButtonBackground;
    public Texture2D creditsButtonBackground;
    public Texture2D quitButtonBackground;

    public void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;

        float menuWidth = 400;  // Define the width of the menu
        float menuHeight = 200; // Define the height of the menu
        float menuX = Screen.width / 2 - menuWidth / 2;  // Calculate the x position
        float menuY = Screen.height - menuHeight; // Calculate the y position

        GUI.BeginGroup(new Rect(menuX, menuY, menuWidth, menuHeight));

        // Define button styles with background images
        GUIStyle startButtonStyle = new GUIStyle(GUI.skin.button);
        startButtonStyle.normal.background = startButtonBackground;

        GUIStyle creditsButtonStyle = new GUIStyle(GUI.skin.button);
        creditsButtonStyle.normal.background = creditsButtonBackground;

        GUIStyle quitButtonStyle = new GUIStyle(GUI.skin.button);
        quitButtonStyle.normal.background = quitButtonBackground;

        if (GUI.Button(new Rect(20, 20, menuWidth - 60, 50), "", startButtonStyle))
        {
            StartGame();
        }
        if (GUI.Button(new Rect(20, 80, menuWidth - 60, 50), "", creditsButtonStyle))
        {
            StartCredits();
        }
        if (GUI.Button(new Rect(20, 140, menuWidth - 60, 50), "", quitButtonStyle))
        {
            Quit();
        }

        GUI.EndGroup();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void StartCredits()
    {
       SceneManager.LoadScene("CreditScene");
    }

    public void Quit()
    {
        UnityEngine.Debug.Log("Quit");
        Application.Quit();
    }
}
