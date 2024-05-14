using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
   // GameManager GM;
    private bool isMenuVisible = true;
    public Texture2D backToMenuButtonBackground;

    void Start()
    {
        isMenuVisible = true;
    }
 void OnGUI()
{
    Cursor.lockState = CursorLockMode.None;
    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
    buttonStyle.normal.textColor = Color.white;
    buttonStyle.hover.textColor = Color.white;
    buttonStyle.normal.background = backToMenuButtonBackground; 

    if (isMenuVisible)
    {
        float menuWidth = 400;
        float menuHeight = 100;
        float menuX = Screen.width / 2 - menuWidth / 2;
        float menuY = Screen.height - menuHeight;

        GUI.BeginGroup(new Rect(menuX, menuY, menuWidth, menuHeight));

        if (GUI.Button(new Rect(10, 10, menuWidth - 20, 50), "", buttonStyle))
        {
            BackToMain();
        }

        GUI.EndGroup();
    }
}

    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }


    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
