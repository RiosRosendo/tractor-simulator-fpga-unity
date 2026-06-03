/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int currentLevel = 1; //Track the current level of the game
    private void Awake(){
        // Just make sure that GameManager exists
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);// Persist GameManager between scenes
        }
        else{
            Destroy(gameObject); // If there is another GameManager instance, it will destroy it
        }
    }
}

//Method to get the current level 
public int GetCurrentLevel(){
    return currentLevel;
}

//Method to load the next level
public void LoadNextLevel(){
    int nextLevelIndex = GetCurrentLevel() + 1;
    string nextSceneName = "Level" + nextLevelIndex;
    //currentLevel++;
    // SceneManager.LoadScene("Level" + currentLevel);
    SceneManager.LoadScene(nextSceneName);
}

//Method to load the Game Over scene
public void LoadGameOverScene(){
    SceneManager.LoadScene(5);
}

//Method to load the Win Scene
public void LoadWinScene(){
    SceneManager.LoadScene(6);
}
*/
//New code: 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int currentLevel = 1; //Track the current level of the game

    private void Awake()
    {
        // Just make sure that GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);// Persist GameManager between scenes
        }
        else
        {
            Destroy(gameObject); // If there is another GameManager instance, it will destroy it
        }
    }

    //Method to get the current level 
    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    //Method to load the next level
    public void LoadNextLevel()
    {
        int nextLevelIndex = GetCurrentLevel() + 1;
        string nextSceneName = "Level" + nextLevelIndex;
        SceneManager.LoadScene(nextSceneName);
    }

    //Method to load the Game Over scene
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(5);
    }

    //Method to load the Win Scene
    public void LoadWinScene()
    {
        SceneManager.LoadScene(6);
    }
}