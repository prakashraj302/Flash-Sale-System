using System.Xml;

namespace Flash_Sale_System.Model
{
    public class Reverstion
    {
        public string reservation_id { get; set; }

        public DateTime ExpireAt { get; set; }
        public bool confimed { get; set; }
    }
}
