using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CannonsManager : MonoBehaviour
{
    private int cannonCount;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject cannonPrefab;
    [SerializeField] private float spacing;
    private List<GameObject> cannons = new List<GameObject>();

    private void Start()
    {
        SetNumberOfCannons(1);
    }

    public void SetNumberOfCannons(int newCannonCount)
    {
        cannonCount = newCannonCount;

        ClearCannonsList();

        FillCannonsList();

        CenterCannons();
    }

    private void ClearCannonsList()
    {
        foreach (GameObject cannon in cannons)
        {
            Destroy(cannon);
        }
        cannons.Clear();
    }

    private void FillCannonsList()
    {
        for (int i = 0; i < cannonCount; i++)
        {
            cannons.Add(Instantiate(cannonPrefab, shootPoint.position, Quaternion.identity, shootPoint));
        }
    }

    private void CenterCannons()
    {
        float margin = ((float)cannonCount - 1) * spacing * 0.5f * -1;

        foreach (GameObject cannon in cannons)
        {
            cannon.transform.localPosition = new Vector3(margin, 0, 0);

            margin += spacing;

        }
    }

}
