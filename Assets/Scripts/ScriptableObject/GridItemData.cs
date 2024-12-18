using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTaskQuizGame
{
    [CreateAssetMenu(fileName = "GridItemData", menuName = "ScriptableObjects/QuizGrid/GridItemData")]
    public class GridItemData : ScriptableObject
    {
        [SerializeField]
        private string _name;
        public string Name => _name;

        [SerializeField]
        private Sprite _sprite;
        public Sprite Sprite => _sprite;
    }
}
