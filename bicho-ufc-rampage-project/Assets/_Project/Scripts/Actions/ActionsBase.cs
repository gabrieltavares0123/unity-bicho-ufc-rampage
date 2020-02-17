using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magrathea.bufcr.Actions
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ActionsBase : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody2D;

        protected virtual void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            if (CanDoAction())
            {
                DoAction();
            }
        }

        protected abstract bool CanDoAction();

        protected abstract void DoAction();
    }
}