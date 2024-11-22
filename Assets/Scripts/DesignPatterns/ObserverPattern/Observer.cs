using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 서브젝트를 관찰하는 옵저버 클래스
// 추상 클래스로 구현
public abstract class Observer : MonoBehaviour
{
    // 서브젝트의 변화를 알리는 메서드
    // 서브젝트에서 직접 콜하는 메서드임.
    public abstract void Notify(Subject subject);

}
