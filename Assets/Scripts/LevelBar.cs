using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private Transform EndPoint;
    [SerializeField]
    private Slider _slider;

    private float maxDistance;
    void Start()
    {
        maxDistance = getDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.z <= maxDistance && Player.position.z <= EndPoint.position.z)
        {
            float distance = 1 - (getDistance() / maxDistance);
            setProgress(distance);
        }
    }

    float getDistance()
    {
        return Vector3.Distance(Player.position, EndPoint.position);
    }

    void setProgress(float p)
    {
        _slider.value = p;
    }
}
