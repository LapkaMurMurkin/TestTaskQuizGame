using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTaskQuizGame
{
    public class LevelLoader : MonoBehaviour
    {
        private List<Level> _levels;
        private Grid _grid;
        private TaskTracker _taskTracker;

        private int _currentLevel;

        public static Action GameEnded;

        public void Initialize(List<Level> levels, Grid grid, TaskTracker taskTracker)
        {
            _levels = levels;
            _grid = grid;
            _taskTracker = taskTracker;

            _currentLevel = 0;
            LoadLevel(_levels[_currentLevel]);

            foreach (GridItem item in _grid.ActiveItems)
                DOTweenAnimator.FadeInBounce(item.transform, 0.5f, 0.5f);

            TaskTracker.AnsweredCorrectly += LoadNextLevel;
        }

        private void OnDestroy()
        {
            TaskTracker.AnsweredCorrectly -= LoadNextLevel;
        }

        private void LoadNextLevel()
        {
            if (_currentLevel < _levels.Count - 1)
            {
                _currentLevel++;
                LoadLevel(_levels[_currentLevel]);
            }
            else
                GameEnded?.Invoke();
        }

        private void LoadLevel(Level level)
        {
            _grid.ClearItems();
            _grid.LoadItems(level);
            _taskTracker.SetRandomTask(level);
        }
    }
}
