using System;

namespace GameEngine.Models
{
    public class EnemyCreationException : Exception
    {
        public EnemyCreationException(string message, string enemyName) : base(message)
        {
            RequestedEnemyName = enemyName;
        }

        public string RequestedEnemyName { get; private set; }
    }
}
