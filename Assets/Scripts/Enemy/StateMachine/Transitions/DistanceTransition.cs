﻿using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _distance;

    private void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(Target.transform.position, transform.position) <= _distance)
            {
                NeedTransit = true;
            }
        }
    }
}
