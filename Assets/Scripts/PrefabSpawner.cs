using System.Collections;
using TMPro;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] correctItems;
    [SerializeField] private GameObject[] wrongItems;
    [SerializeField] private TextMeshProUGUI productionCount;

    private int _spawnAmount;
    private bool _isPaused;
    private int _processedAmount = 0;
    private void OnEnable()
    {
        GetSpawnAmountValue();
    }
    private void GetSpawnAmountValue()
    {
        _spawnAmount = Random.Range(40, 100);
        StartCoroutine(StartSpawnDelay());
    }
    private IEnumerator StartSpawnDelay()
    {
        SetProductionNumber();
        for (int i = 0; i < _spawnAmount; i++)
        {
            while (_isPaused)
            {
                yield return null;
            }
            int RollDice = Random.Range(0, 6);
            if (RollDice < 5)
            {
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

        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void PauseProduction()
    {
        _isPaused = true;
    }
    public void ResumeProduction()
    {
        _isPaused = false;
    }
    private void SetProductionNumber()
    {
        productionCount.text = "Production: " + _processedAmount + "/" + _spawnAmount.ToString();
    }
    public void UpdateProductionNumber()
    {
        _processedAmount++;
        SetProductionNumber();
    }
    public int SpawnAmount()
    {
        return _spawnAmount;
    }

}
