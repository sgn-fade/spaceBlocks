using UnityEngine;

namespace Scenes.Player
{
    public class PlayerData : MonoBehaviour
    {
        private int _killCount;

        public PlayerData()
        {
            _killCount = 0;
        }
        
        public void incrementKillCount()
        {
            _killCount++;
        }
        public void descrementKillCount()
        {
            _killCount--;
        }

        public int getKillCount()
        {
            return _killCount;
        }
    }
}
