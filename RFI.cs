namespace ReadRfiFromExcel
{
    internal class RFI
    {
        public string Number { get; set; }
        public string Subject { get; set; }
        public string Closed { get; set; }

        public RFI(System.Data.DataRow tableRow)
        {
            this.Number = tableRow.ItemArray[0].ToString();
            this.Subject = tableRow.ItemArray[1].ToString();
            this.Closed = tableRow.ItemArray[2].ToString();
        }
    }
}