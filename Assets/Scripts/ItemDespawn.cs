using TMPro;
using UnityEngine;

public class ItemDespawn : MonoBehaviour
{
    [SerializeField] private PrefabSpawner prefabSpawner;
    [SerializeField] private TextMeshProUGUI percentageText;
    private int _totalSpawnAmount = 0;
    private int _correctItem = 0;
    private int _wrongItem = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CorrectItem"))
        {
            prefabSpawner.UpdateProductionNumber();
            _correctItem++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("WrongItem"))
        {
            prefabSpawner.UpdateProductionNumber();
            _wrongItem++;
            CalculatePercentage();
            Destroy(collision.gameObject);
        }
    }
    private void CalculatePercentage()
    {
        _totalSpawnAmount = prefabSpawner.SpawnAmount();
        if (_totalSpawnAmount > 0)
        {
            float _wrongPercentage = ((float)_wrongItem / _totalSpawnAmount) * 100f;
            percentageText.text = $"Defective Rate: {_wrongPercentage:F2}%";
        }
    }
}
