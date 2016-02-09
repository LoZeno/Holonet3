using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolonetWebControls;
using System.Net;
using DataAccessLayer;
using System.Configuration;
using CommonBusiness.Rete;

namespace Holonet3
{
	public partial class SelezioneRete : HolonetPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Label1.Text = string.Empty;
				ReteManager manager = new ReteManager(DatabaseContext);
				IEnumerable<Rete> networks = manager.GetNetworksForWorkstation(this.IP4Address);
				foreach (var network in networks)
				{
					Label1.Text += network.Fazione + "; ";
				}
			}
		}
	}
}