using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UdemyProject1.Inputs;
using UdemyProject1.Movements;


//namespaceler classlar� birbirinden ay�r�lar
namespace UdemyProject1.Controllers
{
	public class PlayerController : MonoBehaviour
	{
		
		DefaultInput _input;
		Mover _mover;

		bool _isForceUp;

		private void Awake()
		{
			_input = new DefaultInput();
			_mover = new Mover(GetComponent<Rigidbody>());
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
				_mover.FixedTick();
			}
		}
	}
}

