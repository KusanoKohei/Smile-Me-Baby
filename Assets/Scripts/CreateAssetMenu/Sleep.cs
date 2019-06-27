using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Sleep")]

public class Sleep : Item
{
    [SerializeField]
    private float reliefSleep;   //食欲解消数値
    public float MyReliefSleep { get { return reliefSleep; } }

    public override void useItem(StressCtrl stressCtrl)
    {
        stressCtrl.CareSleep(reliefSleep);

    }
}
