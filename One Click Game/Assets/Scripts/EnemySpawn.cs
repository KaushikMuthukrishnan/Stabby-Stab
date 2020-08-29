using System.Collections;
using TMPro;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyParent, levelCounter, scoreCounter, scoreSummary;
    TextMeshProUGUI tmp, scoreTMP, sStmp;
    public static int Score;


    void Start()
    {
        tmp = levelCounter.GetComponent<TextMeshProUGUI>();
        scoreTMP = scoreCounter.GetComponent<TextMeshProUGUI>();
        StartCoroutine(LevelControl());
        Score = 0;
        sStmp = scoreSummary.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ScoreControls();
        sStmp.text = "Your Score: " + Score;
    }

    void ScoreControls()
    {
        scoreTMP.text = "Score: " + Score;
    }

    void SpawnEnemy()
    {
        GameObject enemy;

        float x = Random.Range(-15f, 55f);
        float z = Random.Range(-35f, 35f);

        enemy = Instantiate(enemyParent, new Vector3(x, 0, z), Quaternion.identity);
        enemy.SetActive(true);
        enemy.name = "Enemy";
        enemy.tag = "Enemy";
        enemy.GetComponent<Enemy_AI>().enabled = true;
    }

    int i = 1;
    float maxY = 5;
    IEnumerator LevelControl()
    {
        yield return new WaitForSeconds(1f);
        tmp.alpha = 1f;
        tmp.text = "Level " + i;
        i++;

        yield return new WaitForSeconds(3f);
        tmp.alpha = 0f;

        for (int y = 0; y < maxY; y++)
            SpawnEnemy();

        maxY += Random.Range(0f, 4f);

        yield return new WaitUntil(() => GameObject.FindWithTag("Enemy") == null);
        StartCoroutine(LevelControl());

        yield break;
    }
}
