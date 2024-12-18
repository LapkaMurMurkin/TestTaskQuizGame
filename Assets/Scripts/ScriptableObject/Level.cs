using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TestTaskQuizGame
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/QuizGrid/Level")]
    public class Level : ScriptableObject
    {
        [SerializeField]
        private int _columns;
        public int Columns => _columns;

        [SerializeField]
        private List<GridItemData> _itemDatas;
        public ReadOnlyCollection<GridItemData> ItemDatas => _itemDatas.AsReadOnly();
    }
}
