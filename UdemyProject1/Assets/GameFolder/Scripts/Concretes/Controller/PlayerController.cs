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
				_mover.FixedTick();
			}
		}
	}
}

