using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject tittleScreen;

    public Button restartButton;
    public float spawnRate = 300f;
    private int score;
    public bool isgameActive;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnTargets()
    {
        while (isgameActive)
        {
            yield return new WaitForSeconds(spawnRate);// not clear

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isgameActive = false;
    }

    public void UpdateScore(int updatescore)
    {
        score += updatescore;
        scoreText.text = "Score:  " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStart(int difficulty)
    {
        isgameActive = true;
        spawnRate = spawnRate / difficulty;
        StartCoroutine(SpawnTargets());
        score = 0;
        tittleScreen.gameObject.SetActive(false);
    }
}
