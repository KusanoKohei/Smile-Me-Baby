using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Toys")]

public class Toys : Item
{
    [SerializeField]
    private float reliefToys;   //食欲解消数値
    public float MyReliefToys { get { return reliefToys; } }

    public override void useItem(StressCtrl stressCtrl)
    {
        stressCtrl.CareToys(reliefToys);
    }
}
