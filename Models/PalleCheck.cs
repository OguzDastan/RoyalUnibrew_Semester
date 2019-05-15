using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PalleCheck
    {
        public int LabelNumber { get => _labelNumber; set => _labelNumber = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public DateTime ExpiryDate { get => _expiryDate; set => _expiryDate = value; }
        public string ReceiptForTest { get => _receiptForTest; set => _receiptForTest = value; }
        public string SignFromWorker { get => _signFromWorker; set => _signFromWorker = value; }
        public string ControlOfPalletNumber { get => _controlOfPalletNumber; set => _controlOfPalletNumber = value; }

        private DateTime _date;
        private int _labelNumber;
        private DateTime _expiryDate;
        private string _receiptForTest;
        private string _signFromWorker;
        private string _controlOfPalletNumber;

        public PalleCheck()
        {
        }
    }

    public class PalleCheckManager
    {
        public List<PalleCheck> Entries;

        public PalleCheckManager()
        {
            Entries = new List<PalleCheck>();

            Entries.Add(new PalleCheck() {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
            Entries.Add(new PalleCheck()
            {
                Date = DateTime.Now,
                ExpiryDate = DateTime.Now,
                LabelNumber = 123,
                ReceiptForTest = "En Receipt",
                SignFromWorker = "MNH! THE LEGEND",
                ControlOfPalletNumber = "Klaaaret!"
            });
        }
    }
}
