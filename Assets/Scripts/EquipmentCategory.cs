using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCategory : MonoBehaviour
{
    [SerializeField]
    private NavigationView navigationView;
    [SerializeField]
    private RectTransform rectDetails;


    [SerializeField]
    private GameObject equipmentPrefab;
    [SerializeField]
    private Transform equipmentParent;
    [SerializeField]
    private List<EquipmentTemplate> equipments;

    private void Awake()
    {
        foreach ( var equip in equipments)
        {
            GameObject clone = Instantiate(equipmentPrefab, equipmentParent);

            clone.GetComponent<Equipment>().SetUp(equip);
            clone.GetComponent<EquipmentButton>().SetUp(equip, navigationView, rectDetails);


        }
    }
}
