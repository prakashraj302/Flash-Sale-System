using Flash_Sale_System.Model;

namespace Flash_Sale_System.service
{
    public class inventoryservice : Iinventoryservice
    {
        private int _availableInventory;
        private int _totalInventory;
        private readonly Dictionary<string, Reverstion> _reservation = new Dictionary<string, Reverstion>();
        private readonly Queue<string> _waitlist =new();
        public async Task<object> Initialize(int totalInventory)
        {
            _totalInventory = totalInventory;
            _availableInventory = totalInventory;
            _reservation.Clear();
            _waitlist.Clear();
            return (new {totalInventory, _availableInventory});
            

        }

        public async Task<object> Reserve(string userId)
        {
            if(_availableInventory > 0)
            {
                _availableInventory--;
                var reservation = new Reverstion
                {
                    reservation_id = Guid.NewGuid().ToString(),
                    ExpireAt = DateTime.UtcNow.AddMinutes(5),
                    confimed=false

                };
                _reservation[reservation.reservation_id] = reservation;
                return (new { resverstion_id = reservation.reservation_id, Expire = reservation.ExpireAt });
            }
            _waitlist.Enqueue(userId);
            return (new {message= "Added to waitlist",wishlist_postion = _waitlist.Count });
        }

        public object Status()
        {
            return (new
            {
                avilable_inventory = _availableInventory,
                toral_Invetory = _totalInventory,
                waitlist_size = _waitlist.Count,
            });
        }

        public (int statusCode,object body) confirm(string reservationid)
        {
            if(!_reservation.TryGetValue(reservationid, out var reservation))
            {
                return (409,new  { error="Reservation not found"});
            }
            if (reservation.confimed)
            {
                return (409, new { error = "Reservation already confirmed" });
            }
            reservation.confimed = true;
            return (200, new {status="confirmed", reservationid=reservation.reservation_id});
        }
    }
}
