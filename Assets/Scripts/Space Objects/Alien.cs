using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Space_Objects
{
    public class Alien : ConfigurableSpaceObject
    {
        private Ship _player;

        public Alien(GameObject gameObject, IMediator gameLogic, Ship player, Vector2 position = default) : base(gameObject, gameLogic, position)
        {
            _player = player;
        }

        protected override void ConfigureCollider()
        {
            throw new NotImplementedException();
        }

        protected override void ConfigureGameObject()
        {
            throw new NotImplementedException();
        }

        protected override void ConfigureRigidBody()
        {
            throw new NotImplementedException();
        }
    }
}
