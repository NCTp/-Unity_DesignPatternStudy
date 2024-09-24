using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Subject
{
    private Light[] _lights; // 전구들을 저장할 리스트

    // 씬에 존재하는 모든 전구를 찾아 _lights 리스트에 저장하는 메서드
    void FindLightsInScene()
    {
        _lights = FindObjectsOfType<Light>(); // 씬 위의 모든 전구를 찾아 리스트에 저장.
        //AttachAllLights();
    }

    void AttachAllLights()
    {
        foreach(Light light in _lights)
        {
            Attach(light);
        }
    }
    void DetachAllLights()
    {
        foreach(Light light in _lights)
        {
            Detach(light);
        }
    }
    void OnEnable()
    {
        AttachAllLights();
    }
    void OnDisable()
    {
        DetachAllLights();
    }
    // Start is called before the first frame update
    void Awake()
    {
        FindLightsInScene();
    }

    void OnGUI()
    {
        if(GUILayout.Button("Notify!"))
        {
            NotifyObservers();
        }
    }
}
