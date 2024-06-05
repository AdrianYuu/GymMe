using GymMe.Controllers;
using GymMe.Views.Base;
using System;

namespace GymMe.Views
{
    public partial class TransasctionDetail : BasePage
    {
        private void RefreshGridView(int transactionId)
        {
            var response = TransactionDetailController.GetTransactionDetailsByTransactionId(transactionId);

            if (response.Success)
            {
                GVTransactionDetailData.DataSource = response.Payload;
                GVTransactionDetailData.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int transactionId = Convert.ToInt32(Request.QueryString["transactionid"]);
                RefreshGridView(transactionId);
            }
        }
    }
}