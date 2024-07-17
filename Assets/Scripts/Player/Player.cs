using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class Player : Entity
{
    public static Player instance = null;
        
    public PlayerController _playerController;
    public override void GetDamage(DamageMessage damageMessage)
    {
        health -= damageMessage.amount;
        Debug.Log("Player Health : " + health);
    }
    void OnEnable()
    {
        Debug.Log("I'm Enabled!");
        RunningEventBus.Subscribe(RunningEventType.SKILL, SpecialSkill);
    }
    void OnDisable()
    {
        Debug.Log("I'm Disabled!");
        RunningEventBus.Unsubscribe(RunningEventType.SKILL, SpecialSkill);
    }
    void SpecialSkill()
    {
        Debug.Log("Use the Special Skill!");
    }
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static Player Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    void Start()
    {
        _playerController.PlayerIdle();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _playerController.PlayerIdle();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            _playerController.PlayerMove();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {                
            _playerController.PlayerAttack();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            _playerController.PlayerDead();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RunningEventBus.Publish(RunningEventType.SKILL);
        }
        
        
    }
}

