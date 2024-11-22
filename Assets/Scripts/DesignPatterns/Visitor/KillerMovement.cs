using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerMovement : MonoBehaviour, IElement
{
    public float movementSpeed = 0;
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
    void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(125, 20, 200, 20), "Movement Speed : " + movementSpeed);
    }
}
