using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    public Aidkit potionPrefab;
    public float delayMin = 5;
    public float delayMax = 10;

    private List<Transform> _spawnerPoints;

    private Aidkit _potion;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_potion != null) return;
        if (IsInvoking()) return;

        Invoke("CreatePotion", Random.Range(delayMin, delayMax));
    }

    private void CreatePotion()
    {
        _potion = Instantiate(potionPrefab);
        _potion.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;

    }
}
