using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ICharacter character = new Character();
        character.Attack();
        ICharacter fireCharacter = new Decorator_CharacterFireAttack(character);
        fireCharacter.Attack();
        ICharacter iceCharacter = new Decorator_CharacterIceAttack(character);
        iceCharacter.Attack();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
