using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// Component interface 
public interface ICharacter
{
    public void Attack();
}

// Concrete Component
public class Character : MonoBehaviour, ICharacter
{
    public float power = 10.0f;
    public float speed = 5.0f;

    private Rigidbody2D rb;
    public void Attack()
    {
        Debug.Log("공격!");
    }
    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
}

// Base Decorator
public class CharacterDecorator : ICharacter
{
    protected ICharacter character;
    public CharacterDecorator(ICharacter character)
    {
        this.character = character;
    }
    public virtual void Attack()
    {
        character.Attack();
    }
}

// Decorator - FireAttack
public class Decorator_CharacterFireAttack : CharacterDecorator
{
    public Decorator_CharacterFireAttack(ICharacter character) : base(character) 
    {}
    public override void Attack()
    {
        base.Attack();
        Debug.Log("화염 공격!!");
    }
}

// Decorator - IceAttack
public class Decorator_CharacterIceAttack : CharacterDecorator
{
    public Decorator_CharacterIceAttack(ICharacter character) : base(character)
    {}

    public override void Attack()
    {
        base.Attack();
        Debug.Log("냉기 공격!");
    }
}
