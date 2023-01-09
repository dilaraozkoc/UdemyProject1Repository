using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1.Movements
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float maxFuel = 100f;
        [SerializeField] float currentFuel;
        [SerializeField] ParticleSystem particle;

		public bool IsEmpty => currentFuel < 1;
		private void Awake()
		{
			currentFuel = maxFuel;
		}

		public void IncreaseFuel(float _increase)
		{
			currentFuel += _increase;
			currentFuel = Mathf.Min(currentFuel,maxFuel);

			if (particle.isPlaying)
			{
				particle.Stop();
			}
		}

		public void DecreaseFuel(float decrease)
		{
			currentFuel -= decrease;
			currentFuel = Mathf.Max(currentFuel, 0);
			if (particle.isStopped)
			{
				particle.Play();
			}
		}
	}
}

