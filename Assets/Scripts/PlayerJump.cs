using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class PlayerJump : Command
{
    private PlayerController _playerController;

    // 생성자
    public PlayerJump(PlayerController playerController)
    {
        _playerController = playerController;
    }
    // 실행할 내용을 포함하는 Execute 메서드
    public override void Execute()
    {
        _playerController.Jump();

    }
}
