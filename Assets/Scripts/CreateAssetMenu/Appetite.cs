using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Items/Appetite")]

public class Appetite : Item {

    [SerializeField]
    private float reliefAppetite;   //食欲解消数値
    public float MyReliefAppetite{ get{ return reliefAppetite;}}

    public override void useItem(StressCtrl stressCtrl)
    {
        stressCtrl.CareAppetite(reliefAppetite);
    }
}
