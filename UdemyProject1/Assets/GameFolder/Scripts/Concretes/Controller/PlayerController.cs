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
		Fuel _fuel;

		bool _canForceUp;
		float _leftRight;

		public float TurnSpeed => _turnSpeed;
		public float Force => _force;
		private void Awake()
		{
			_input = new DefaultInput();
			_mover = new Mover(this);
			_rotator = new Rotator(this);
			_fuel = GetComponent<Fuel>();
		}

		private void Update()
		{
			Debug.Log(_input.LeftRight);
			//Inputlar
			//Her bir frame'de bir çalýþýr
			if (_input.isForceUp && !_fuel.IsEmpty)
			{
				_canForceUp = true;
			}
			else
			{
				_canForceUp = false;
				_fuel.IncreaseFuel(0.01f);
			}
			_leftRight = _input.LeftRight;
		}

		private void FixedUpdate()
		{
			//Physic operations
			//hiç bir iþlem olmazsa 0.02sn de çalýþýr. Fizik motoruyla sekronize çalýþýr

			if (_canForceUp)
			{
				_mover.FixedTick();
				_fuel.DecreaseFuel(0.2f);
			}
			_rotator.FixedTick(_leftRight);
		}
	}
}

