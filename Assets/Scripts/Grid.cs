using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace TestTaskQuizGame
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        private GridLayoutGroup gridLayoutGroup;

        [SerializeField]
        private GridItem _gridItemPrefab;

        private List<GridItem> _activeItems;
        public ReadOnlyCollection<GridItem> ActiveItems => _activeItems.AsReadOnly();
        private List<GridItem> _inactiveItems;

        public void Initialize()
        {
            _activeItems = new List<GridItem>();
            _inactiveItems = new List<GridItem>();

            foreach (Transform child in transform)
            {
                GridItem gridItem = child.GetComponent<GridItem>();
                DeactivateItem(gridItem);
            }
        }

        public void ClearItems()
        {
            while (_activeItems.Count > 0)
                DeactivateItem(_activeItems[0]);
        }

        public void LoadItems(Level level)
        {
            gridLayoutGroup.constraintCount = level.Columns;

            foreach (GridItemData gridItemData in level.ItemDatas)
            {
                GridItem item;

                if (_inactiveItems.Count > 0)
                    item = _inactiveItems[0];
                else
                    item = Instantiate(_gridItemPrefab, transform);

                item.Initialize(gridItemData);
                ActivateItem(item);
            }
        }

        private void ActivateItem(GridItem item)
        {
            _activeItems.Add(item);
            _inactiveItems.Remove(item);
            item.gameObject.SetActive(true);
        }

        private void DeactivateItem(GridItem item)
        {
            item.gameObject.SetActive(false);
            _inactiveItems.Add(item);
            _activeItems.Remove(item);
        }
    }
}
