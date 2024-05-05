using System;
using UnityEngine;

namespace Scenes.GameManager
{
    public interface IGameController
    {
        static event Action<int> OnEnemyKilled;


    }
}
