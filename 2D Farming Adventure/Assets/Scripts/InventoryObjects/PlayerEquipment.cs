using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
