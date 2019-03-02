using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Attractor : MonoBehaviour
{
    private const float G = 667.4f;

    private static List<Attractor> _attractors;

    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        foreach (var attractor in _attractors)
            if (attractor != this)
                Attract(attractor);
    }

    private void OnEnable()
    {
        if (_attractors == null)
            _attractors = new List<Attractor>();

        _attractors.Add(this);
    }

    private void OnDisable()
    {
        _attractors.Remove(this);
    }

    private void Attract(Attractor objToAttract)
    {
        var rbToAttract = objToAttract._rb;

        var direction = _rb.position - rbToAttract.position;
        var distance = direction.magnitude;

        if (distance == 0f)
            return;

        var forceMagnitude = G * ((_rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2));
        var force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}