using UnityEngine;
using SpaceShooter;
using System;

namespace TD
{
    public class TD_PatrolController : AIController
    {
        private Path _path;
        private int _pathIndex;
        public void SetPath(Path path)
        {
            _path = path;
            _pathIndex = 0;
            SetPatrolBehaviour(_path[_pathIndex]);
        }

        protected override void GetNewPoint()
        {
            _pathIndex++;
            if (_path.length > _pathIndex)
            {
                SetPatrolBehaviour(_path[_pathIndex]);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
