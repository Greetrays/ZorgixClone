using UnityEngine;

public class TargetFlyState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
            Rotate();
        }
    }

    private void Rotate()
    {
        float correctionDegree = 180;
        Vector3 difference = Target.transform.position - transform.position;
        difference.Normalize();
        float zRotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation - correctionDegree);
    }
}
