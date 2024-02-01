using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class LookAtPlayer : MonoBehaviour
	{

		private PlayerController player;
		[Inject]
		public void Construct(PlayerController _player)
		{
			player = _player;
		}
		private void Update()
		{
			this.transform.LookAt(player.transform.position);
		}
	}
}