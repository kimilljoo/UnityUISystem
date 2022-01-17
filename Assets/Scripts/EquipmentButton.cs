using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    private EquipmentTemplate equipment;
    private NavigationView navigationView;
    private RectTransform rectDetails;

    public void SetUp(EquipmentTemplate equipment, NavigationView navigationView, RectTransform rectDetails)
    {

        this.equipment = equipment;
        this.navigationView = navigationView;
        this.rectDetails = rectDetails;

        GetComponent<Button>().onClick.AddListener(OnclickBtnEvent);


    }

    public void OnclickBtnEvent()
    {
        rectDetails.GetComponent<Equipment>().SetUp(equipment);
        navigationView.Push(rectDetails);
    }


}
