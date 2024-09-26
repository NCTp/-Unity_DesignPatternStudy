using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerWeapon : MonoBehaviour, IElement
{
    public float attackPower = 0;
    public float attackSpeed = 0;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(125, 40, 200, 20), "Weapon Power : " + attackPower);
        GUI.Label(new Rect(125, 60, 200, 20), "Weapon Speed: " + attackSpeed);
    }
}
