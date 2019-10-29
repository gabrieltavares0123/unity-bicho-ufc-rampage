
namespace Magrathea.BichoUFCRampage.Controls
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Dasher : MonoBehaviour, IDashable
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void DoDash(float boost)
        {
            Vector2 boostVector = new Vector2(boost, 0);
            _rigidbody2D.AddForce(boostVector, ForceMode2D.Impulse);
        }
    }
}