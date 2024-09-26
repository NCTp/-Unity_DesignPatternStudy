using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientVisitor : MonoBehaviour
{
    public KillerPowerUp attackPowerPowerUp;
    public KillerPowerUp attackSpeedPowerUp;
    public KillerPowerUp movementSpeedPowerUp;

    private KillerController _killerController;

    // Start is called before the first frame update
    void Start()
    {
        _killerController = gameObject.AddComponent<KillerController>();
    }

    void OnGUI()
    {
        if(GUILayout.Button("Attack Power UP"))
        {
            _killerController.Accept(attackPowerPowerUp);
        }
        if(GUILayout.Button("Attack speed UP"))
        {
            _killerController.Accept(attackSpeedPowerUp);
        }
        if(GUILayout.Button("Movement Speed UP"))
        {
            _killerController.Accept(movementSpeedPowerUp);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
