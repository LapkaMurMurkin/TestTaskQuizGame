using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTaskQuizGame
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private List<Level> _levels;

        [SerializeField]
        private Grid _grid;

        [SerializeField]
        private TaskTracker _taskTracker;

        [SerializeField]
        private LevelLoader _levelLoader;

        [SerializeField]
        private WinSceen _winSceen;

        private void Awake()
        {
            _grid.Initialize();
            _taskTracker.Initialize();
            _levelLoader.Initialize(_levels, _grid, _taskTracker);
            _winSceen.Initialize();
        }
    }
}
