using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Items/Diapers")]

public class Diapers: Item
{
    [SerializeField]
    private float reliefDiapers;   //おむつ欲解消数値
    public float MyReliefDiapers { get { return reliefDiapers; } }

    public override void useItem(StressCtrl stressCtrl)
    {
        stressCtrl.CareDiapers(reliefDiapers);
    }
}