using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UdemyProject1.Inputs;
using UdemyProject1.Movements;


//namespaceler classlarý birbirinden ayýrýlar
namespace UdemyProject1.Controllers
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] float _turnSpeed = 10f;
		[SerializeField] float _force = 55f;

		DefaultInput _input;
		Mover _mover;
		Rotator _rotator;

		bool _isForceUp;
		float _leftRight;

		public float TurnSpeed => _turnSpeed;
		public float Force => _force;
		private void Awake()
		{
			_input = new DefaultInput();
			_mover = new Mover(this);
			_rotator = new Rotator(this);
		}

		private void Update()
		{
			Debug.Log(_input.LeftRight);
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
			_leftRight = _input.LeftRight;
		}

		private void FixedUpdate()
		{
			//Physic operations
			//hiç bir iþlem olmazsa 0.02sn de çalýþýr. Fizik motoruyla sekronize çalýþýr

			if (_isForceUp)
			{
				_mover.FixedTick();
			}
			_rotator.FixedTick(_leftRight);
		}
	}
}

