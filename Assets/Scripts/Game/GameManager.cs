using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> levelList = new List<GameObject>();
    public GameObject currentLevel;
    public int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        CheckLevelLoading();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        currentLevel = levelList[currentLevelIndex];
        CheckLevelLoading();
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




}
