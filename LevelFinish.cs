using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelFinish : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI levelEndText;

    [SerializeField] GameObject restartButton;

    Scene scene;
    Apples apples;

    int activeSceneIndex;

  

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        levelEndText.text = "";
        restartButton.SetActive(false);

        SceneInfo();
        apples = FindObjectOfType<Apples>();
    }

 
    void Update()
    {
        
    }

    private void SceneInfo()
    {
        scene = SceneManager.GetActiveScene();
        activeSceneIndex = scene.buildIndex;
    }

    public void LevelEndSituation()
    {
        levelEndText.text = "Game End! \n Score: "+ apples.score;
        restartButton.SetActive(true);

    }
    
    
    public void Restart()
    {
        SceneManager.LoadScene(activeSceneIndex);
    }

 


  
}
