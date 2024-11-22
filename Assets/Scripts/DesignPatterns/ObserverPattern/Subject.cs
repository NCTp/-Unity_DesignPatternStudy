using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private readonly ArrayList _observers = new ArrayList(); // 서브젝트를 관측하는 옵저버들


    // 옵저버를 리스트에 추가
    public void Attach(Observer observer)
    {
        _observers.Add(observer);
    }

    // 옵저버를 리스트에서 제거
    public void Detach(Observer observer)
    {
        _observers.Remove(observer);
    }
    // 서브젝트의 변화를 옵저버들에게 통지하는 메서드
    public void NotifyObservers()
    {
        foreach(Observer observer in _observers)
        {
            observer.Notify(this);
        }
    }
}
