namespace Messages.Commands
{
    public class CreateClientCommand : BusMessage
    {
        public string ClientID { get; set; }
        public string Name { get; set; }
        public double InitialDeposit { get; set; }
    }
}
