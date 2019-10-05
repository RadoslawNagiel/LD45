using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] int minModules = 5;
    [SerializeField] int maxModules = 20;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject[] modules;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject enemyMainDot = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            GameObject currentObject = enemyMainDot;
            int modulesAmount = Random.Range(minModules, maxModules);
            while(modulesAmount-- > 0)
            {
                //Vector2 direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
                Vector2 direction = Random.insideUnitCircle.normalized;

                GameObject module = randomModule();
                Vector2 betweenMiddles =
                    currentObject.GetComponent<Renderer>().bounds.size / 2 +
                    module.GetComponent<Renderer>().bounds.size / 2;
                Vector3 targetLocation = (Vector2) currentObject.transform.position + direction * betweenMiddles;

                currentObject = Instantiate(module, targetLocation, Quaternion.identity, enemyMainDot.transform);
            }
        }
    }

    private GameObject randomModule() => modules[Random.Range(0, modules.Length)];
}
