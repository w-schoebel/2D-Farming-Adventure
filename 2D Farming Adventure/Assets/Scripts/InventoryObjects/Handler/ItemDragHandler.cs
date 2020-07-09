using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects.Handler
{
    public class ItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public static ItemDragHandler Instance { get; private set; }

        private Canvas canvas;
        private CanvasGroup canvasGroup;
        private RectTransform rectTransform;
        private RectTransform SlotTransforms;
        private Vector2 originalPosition;
        private Item item;
        private int itemPosition;

        private void Awake()
        {
            Instance = this;
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponentInParent<Canvas>();
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            originalPosition = rectTransform.position; //store originalPosition from IconTransform 
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = .6f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out Vector2 pos);
            rectTransform.position = canvas.transform.TransformPoint(pos);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            rectTransform.position = originalPosition; //set IconTransform back to original Position, so that future items can be shown on the right position in Inventory
        }

        public Item GetItem()
        {
            return item;
        }

        public void SetItem(Item item)
        {
            this.item = item;
        }

        public int GetItemPosition()
        {
            return itemPosition;
        }

        public void SetItemPosition(int itemPosition)
        {
            this.itemPosition = itemPosition;
        }
    }
}
