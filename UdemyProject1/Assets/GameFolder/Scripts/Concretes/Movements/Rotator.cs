using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject1.Controllers;



namespace UdemyProject1.Movements
{
	public class Rotator
	{
		Rigidbody _rigidbody;
		PlayerController _playerController;

		public Rotator(PlayerController playerController)
		{
			_playerController = playerController;
			_rigidbody = playerController.GetComponent<Rigidbody>();
		}

		public void FixedTick(float direction)
		{
			if (direction == 0 )
			{
				if (_rigidbody.freezeRotation )
				{
					_rigidbody.freezeRotation = false;
				}
				return;
			}
			if (!_rigidbody.freezeRotation) _rigidbody.freezeRotation = true;

			_playerController.transform.Rotate(Vector3.right* -1* Time.deltaTime * direction * _playerController.TurnSpeed);
		}
	}
}

