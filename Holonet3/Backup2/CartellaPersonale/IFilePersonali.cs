using System;
namespace Holonet3.CartellaPersonale
{
	public interface IFilePersonali
	{
		DataAccessLayer.MessaggioSalvato FileDaMostrare { get; set; }
		void MostraFile();
	}
}
