using GymMe.Controllers;
using GymMe.Datasets;
using GymMe.Models;
using GymMe.Reports;
using GymMe.Views.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views.Admin
{
    public partial class TransactionReportPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            if (user.UserRole != "Admin") Response.Redirect("~/Views/HomePage.aspx");

            var firstResponse = TransactionHeaderController.GetTransactionHeaders();

            if (!firstResponse.Success)
            {
                return;
            }

            var secondResponse = SupplementController.GetSupplements();

            if(!secondResponse.Success)
            {
                return;
            }

            var thirdResponse = SupplementTypeController.GetSupplementTypes();

            if(!thirdResponse.Success)
            {
                return;
            }

            TransactionReport report = new TransactionReport();
            CrystalReportViewer.ReportSource = report;
            report.SetDataSource(GetDataSet(firstResponse.Payload, secondResponse.Payload, thirdResponse.Payload));
        }
        public TransactionDataset GetDataSet(List<TransactionHeader> transactionHeaders, List<MsSupplement> supplements, List<MsSupplementType> supplementTypes)
        {
            TransactionDataset transactionDataset = new TransactionDataset();
            var transactionHeaderTable = transactionDataset.TransactionHeader;
            var transactionDetailTable = transactionDataset.TransactionDetail;
            var supplementTable = transactionDataset.MsSupplement;
            var supplementTypeTable = transactionDataset.MsSupplementType;

            foreach (MsSupplement x in supplements)
            {
                var supplementTableRow = supplementTable.NewRow();
                supplementTableRow["SupplementID"] = x.SupplementID;
                supplementTableRow["SupplementName"] = x.SupplementName;
                supplementTableRow["SupplementExpiryDate"] = x.SupplementExpiryDate;
                supplementTableRow["SupplementPrice"] = x.SupplementPrice;
                supplementTableRow["SupplementTypeID"] = x.SupplementTypeID;
                supplementTable.Rows.Add(supplementTableRow);
            }

            foreach (MsSupplementType x in supplementTypes)
            {
                var supplementTypeTableRow = supplementTypeTable.NewRow();
                supplementTypeTableRow["SupplementTypeID"] = x.SupplementTypeID;
                supplementTypeTableRow["SupplementTypeName"] = x.SupplementTypeName;
                supplementTypeTable.Rows.Add(supplementTypeTableRow);
            }

            foreach (TransactionHeader t in transactionHeaders)
            {
                var transactionHeaderTableRow = transactionHeaderTable.NewRow();
                transactionHeaderTableRow["TransactionID"] = t.TransactionID;
                transactionHeaderTableRow["UserID"] = t.UserID;
                transactionHeaderTableRow["TransactionDate"] = t.TransactionDate;
                transactionHeaderTableRow["Status"] = t.Status;
                transactionHeaderTable.Rows.Add(transactionHeaderTableRow);

                foreach (TransactionDetail x in t.TransactionDetails)
                {
                    var transactionDetailRow = transactionDetailTable.NewRow();
                    transactionDetailRow["TransactionID"] = t.TransactionID;
                    transactionDetailRow["SupplementID"] = x.SupplementID;
                    transactionDetailRow["Quantity"] = x.Quantity;
                    transactionDetailTable.Rows.Add(transactionDetailRow);
                }
            }

            return transactionDataset;
        }
    }
}