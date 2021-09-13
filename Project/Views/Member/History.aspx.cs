using Project.Report;
using Project.Dataset;
using Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Model;

namespace Project.Views.Member
{
    public partial class History : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            MsMember member = (MsMember)Session["member"];
            if(member == null)
            {
                Response.Redirect("~/Views/Auth/Login.aspx");
            }

            CrystalReport crystal = new CrystalReport();
            CrystalReportViewer.ReportSource = crystal;

            var id = member.MemberId;

            var data = MemberController.history(id);

            crystal.SetDataSource(getDataSet(data));
        }

        private DataSet1 getDataSet(List<TrDetail> detail)
        {
            DataSet1 ds = new DataSet1();

            var table = ds.TrDetail;

            foreach(TrDetail d in detail)
            {

                var flower = FlowerController.FindById(d.FlowerId);

                var row = table.NewRow();
                row["TransactionId"] = d.TransactionId;
                row["FlowerId"] = d.FlowerId;
                row["FlowerName"] = flower.FlowerName;
                row["Quantity"] = d.Quantity;
                row["SubTotal"] = d.Quantity * flower.FlowerPrice;
                table.Rows.Add(row);
            }

            return ds;

        }

    }
}