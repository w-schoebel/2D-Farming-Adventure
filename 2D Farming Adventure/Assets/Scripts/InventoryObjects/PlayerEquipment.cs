namespace Assets.Scripts.InventoryObjects
{
    public class PlayerEquipment
    {
        EquipmentSlot head;
        EquipmentSlot body;
        EquipmentSlot feet;

        public PlayerEquipment(EquipmentSlot head, EquipmentSlot body, EquipmentSlot feet)
        {
            this.head = head;
            this.body = body;
            this.feet = feet;
        }
    }
}
