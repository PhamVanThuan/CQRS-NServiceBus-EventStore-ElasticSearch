namespace Messages.Commands
{
    public class WithdrawMoneyCommand : BusMessage
    {
        public string ClientID { get; set; }
        public double Quantity { get; set; }
        public bool FromATM { get; set; }
    }
}
