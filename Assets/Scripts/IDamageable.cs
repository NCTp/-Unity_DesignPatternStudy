using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageMessage
{
    public DamageMessage(GameObject _gameObject, float _amount)
    {
        gameObject = _gameObject;
        amount = _amount;

    }
    public GameObject gameObject;
    public float amount;
}
public interface IDamageable
{
    public virtual void GetDamage()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
