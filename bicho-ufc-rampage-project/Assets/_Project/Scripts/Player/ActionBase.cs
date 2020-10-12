using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ActionBase : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public abstract void DoAction();
}
