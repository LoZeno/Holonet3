using System;
namespace Holonet3.Messaggi
{
	public interface IMessaggi
	{
		bool IsInUscita { get; set; }
		DataAccessLayer.Missione MessaggioVisualizzato { get; set; }
		void MostraMessaggio();
		void MostraMessaggioInUscita();
	}
}
