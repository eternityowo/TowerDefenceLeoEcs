using TowerDefenceLeoEcs.Pooling;

namespace TowerDefenceLeoEcs.Services
{
    public class PoolsObject
    {
        private const string pathEnemy = "Prefabs/Enemy";

        public PoolContainer Enemies { get; }

        public PoolsObject()
        {
            Enemies = PoolContainer.CreatePool<PoolObjectExt>(pathEnemy);
        }
    }
}