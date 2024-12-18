using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestTaskQuizGame
{
    public class TaskTracker : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _taskText;
        private string _currentTask;
        private List<string> _previousTasks;

        [SerializeField]
        private ParticleSystem _starsEffect;

        public static Action AnsweredCorrectly;

        public void Initialize()
        {
            _previousTasks = new List<string>();

            _taskText.color = new Color(0, 0, 0, 0);
            DOTweenAnimator.FadeInUI(_taskText, 2);

            GridItem.Clicked += CheckAnswer;
        }

        private void OnDestroy()
        {
            GridItem.Clicked -= CheckAnswer;
        }

        private void CheckAnswer(GridItem item)
        {
            if (item.Data.Name == _currentTask)
            {
                _starsEffect.transform.position = item.transform.position;
                _starsEffect.Play();

                DOTweenAnimator.FadeInBounce(item.transform, 0.5f)
                .OnComplete(() => AnsweredCorrectly?.Invoke());
            }
            else
                DOTweenAnimator.ShakePosition(item.transform, 0.5f);
        }

        public void SetRandomTask(Level level)
        {
            _currentTask = GetRandomTask(level.ItemDatas.ToList());
            _taskText.text = $"Find {_currentTask}";

            _previousTasks.Add(_currentTask);
        }

        private string GetRandomTask(List<GridItemData> items)
        {
            int randomItemIndex;
            GridItemData randomItem;

            do
            {
                randomItemIndex = UnityEngine.Random.Range(0, items.Count);
                randomItem = items[randomItemIndex];

                if (_previousTasks.Contains(randomItem.Name))
                    items.Remove(randomItem);
                else
                    return randomItem.Name;
            }
            while (items.Count > 0);

            return "Error";
        }
    }
}
