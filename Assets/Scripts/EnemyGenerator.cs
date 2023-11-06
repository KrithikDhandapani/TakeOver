using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemeyCount;
    public int maxEnemies;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemeyCount < maxEnemies)
        {
            xPos = Random.Range(1, 50);
            zPos = Random.Range(1, 31);
            Instantiate(theEnemy, spawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
            enemeyCount += 1;
        }
    }

   
}
