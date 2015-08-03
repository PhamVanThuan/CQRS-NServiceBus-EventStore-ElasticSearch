namespace Messages.Commands
{
    public class DepositMoneyCommand : BusMessage
    {
        public string ClientID { get; set; }  
        public double Quantity { get; set; }
        public bool FromATM { get; set; }
    }
}
