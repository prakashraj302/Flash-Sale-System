namespace Flash_Sale_System.service
{
    public interface Iinventoryservice
    {
        public Task<object> Initialize(int totalInventory);

        public Task<object> Reserve(string userId);

        public object Status();

        public (int statusCode,object body) confirm(string reservationid);
    }
}
