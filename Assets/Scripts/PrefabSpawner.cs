using System.Collections;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] correctItems;
    [SerializeField] private GameObject[] wrongItems;

    private int SpawnAmount;

    private void OnEnable()
    {
        GetSpawnAmountValue();
    }
    private void GetSpawnAmountValue()
    {
        SpawnAmount = Random.Range(40, 100);
        StartCoroutine(StartSpawnDelay());
    }
    private IEnumerator StartSpawnDelay()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            int RollDice = Random.Range(0, 6);
            if (RollDice < 5)
            {
                // Outcome is 0-4: Spawn a "correct" object
                SpawnCorrectItem();
            }
            else
            {
                SpawnWrongItem();
            }
            yield return new WaitForSeconds(2f);
        }
    }
    private void SpawnCorrectItem()
    {
        GameObject prefab = correctItems[Random.Range(0, correctItems.Length)];

        Instantiate(prefab, transform.position, Quaternion.identity);
    }
    private void SpawnWrongItem()
    {
        GameObject prefab = wrongItems[Random.Range(0, wrongItems.Length)];

        // Spawn the item
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
