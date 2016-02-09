using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Holonet3.Utilities
{
	public interface IHackablePage
	{
		bool Hacked { get; set;}

		void OnHackedSuccess(long hackerAccount);

		void OnHackedFailure(long hackerAccount);
	}
}
