/* Author Wiebke Schöbel
 * Created at 15.06.2020
 * Version 4
 * 
 * EventHandler for ItemDragHandling
 */
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects.Handler
{
    /// <summary>
    /// EventHandler for ItemDragHandling
    /// </summary>
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

        /// <summary>
        /// Stores the currentPosition on start of dragging
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            originalPosition = rectTransform.position; //store originalPosition from IconTransform 
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = .6f;
        }

        /// <summary>
        /// Shows the items following the mouse
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out Vector2 pos);
            rectTransform.position = canvas.transform.TransformPoint(pos);
        }

        /// <summary>
        /// Returns the Item to the start position if no other handling is done
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            rectTransform.position = originalPosition; //set IconTransform back to original Position, so that future items can be shown on the right position in Inventory
        }

        /// <summary>
        /// Returns the Item
        /// </summary>
        /// <returns></returns>
        public Item GetItem()
        {
            return item;
        }

        /// <summary>
        /// Sets the given Item
        /// </summary>
        /// <param name="item"></param>
        public void SetItem(Item item)
        {
            this.item = item;
        }

        /// <summary>
        /// Returns the ItemPosition
        /// </summary>
        /// <returns></returns>
        public int GetItemPosition()
        {
            return itemPosition;
        }

        /// <summary>
        /// Sets the given ItemsPosition 
        /// </summary>
        /// <param name="itemPosition"></param>
        public void SetItemPosition(int itemPosition)
        {
            this.itemPosition = itemPosition;
        }
    }
}
