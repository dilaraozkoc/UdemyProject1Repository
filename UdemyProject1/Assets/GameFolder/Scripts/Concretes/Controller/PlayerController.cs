using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UdemyProject1.Inputs;


//namespaceler classlarý birbirinden ayýrýlar
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
			//Her bir frame'de bir çalýþýr
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
			//hiç bir iþlem olmazsa 0.02sn de çalýþýr. Fizik motoruyla sekronize çalýþýr

			if (_isForceUp)
			{
				_rigidbody.AddForce(Vector3.up *_force * Time.deltaTime);
			}
		}
	}
}

