using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public enum RunningEventType
{
    SKILL
}
public class RunningEventBus : MonoBehaviour
{
    private static readonly IDictionary<RunningEventType, UnityEvent> // 다른 오브젝트가 덮어쓰지 못하도록 private / readonly로 선언
    Events = new Dictionary<RunningEventType, UnityEvent>(); // 이벤트들

    /*
    Subscribe 메서드
    입력 파라미터 : 러닝 이벤트 종류, 콜백 함수
    Subscribe 메서드를 통해 특정 이벤트 타입의 구독자로 자신을 추가.
    */
    public static void Subscribe(RunningEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if(Events.TryGetValue(eventType, out thisEvent)) 
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }
    /*
    Unsubscribe 메서드
    입력 파라미터 : 러닝 이벤트 종류, 콜백 함수
    특정 이벤트를 구독하는 오브젝트를 삭제.
    */
    public static void Unsubscribe(RunningEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;
        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    /*
    Publish 메서드
    입력 파라미터 : 러닝 이벤트 종류
    특정 이벤트를 게시한다. 특정 이벤트의 구독자들은 확인할 수 있다.
    */
    public static void Publish(RunningEventType eventType)
    {
        UnityEvent thisEvent;
        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
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
