using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerController : MonoBehaviour, IElement
{
    private List<IElement> _killerElements = new List<IElement>();
    public void Accept(IVisitor visitor)
    {
        foreach (IElement element in _killerElements)
        {
            element.Accept(visitor);
        }
    }
    void Start()
    {
        _killerElements.Add(gameObject.AddComponent<KillerWeapon>());
        _killerElements.Add(gameObject.AddComponent<KillerMovement>());
    }

}
