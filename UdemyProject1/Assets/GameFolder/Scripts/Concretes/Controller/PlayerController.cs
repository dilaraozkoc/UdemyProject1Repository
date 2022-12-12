using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UdemyProject1.Inputs;


//namespaceler classlar� birbirinden ay�r�lar
namespace UdemyProject1.Controllers
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] float _force;
		Rigidbody _rigidbody;
		DefaultInput _input;

		bool _isForceUp;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_input = new DefaultInput();
		}

		private void Update()
		{
			Debug.Log(_isForceUp);
			//Inputlar
			//Her bir frame'de bir �al���r
			if (_input.isForceUp)
			{
				_isForceUp = true;
			}
			else
			{
				_isForceUp = false;
			}
		}

		private void FixedUpdate()
		{
			//Physic operations
			//hi� bir i�lem olmazsa 0.02sn de �al���r. Fizik motoruyla sekronize �al���r

			if (_isForceUp)
			{
				_rigidbody.AddForce(Vector3.up *_force * Time.deltaTime);
			}
		}
	}
}

