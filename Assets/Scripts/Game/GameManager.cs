using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> levelList = new List<GameObject>();
    public GameObject currentLevel;
    public int currentLevelIndex = 0;

    public PlayerManager player;


    public GameObject winUI, deadUI;
    public DynamicMoveProvider playerMovement;

    public Transform currentCheckpoint;

    // Start is called before the first frame update
    void Awake()
    {
        //CheckLevelLoading();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        currentLevel = levelList[currentLevelIndex];
        CheckLevelLoading();
        */
    }

    void CheckLevelLoading()
    {
        int i = levelList.FindIndex(x => x.Equals(currentLevel));
        
        foreach (GameObject level in levelList) 
        {
            if(level.activeInHierarchy == true)
            {

                level.SetActive(false);
            }
        }

        currentLevel.SetActive(true);

        if(i > 0)
        {
            levelList[i-1].SetActive(true);
        }

        if(i + 1 < levelList.Count)
        {
            levelList[i+1].SetActive(true);
        }

        
    }

    void NextLevel()
    {
        currentLevelIndex++;
        currentLevel = levelList[currentLevelIndex];
    }
    void PrevLevel()
    {
        currentLevelIndex--;
        currentLevel = levelList[currentLevelIndex];
    }

    public void SetLevelIndex(int i)
    {
        currentLevelIndex = i;
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void Win()
    {
        winUI.SetActive(true);
        playerMovement.enabled = false;
        
    }

    public void PlayerKill()
    {
        deadUI.SetActive(true);
        playerMovement.enabled = false;
    }

    public void Respawn()
    {
        player.transform.position = currentCheckpoint.position + new Vector3(0, 0f, 0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }




}
