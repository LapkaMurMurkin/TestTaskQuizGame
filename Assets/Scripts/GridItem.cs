
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestTaskQuizGame
{
    public class GridItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _image;
        
        private GridItemData _data;
        public GridItemData Data => _data;

        public static Action<GridItem> Clicked;

        public void Initialize(GridItemData data)
        {
            _data = data;
            _image.sprite = _data.Sprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke(this);
        }
    }
}
