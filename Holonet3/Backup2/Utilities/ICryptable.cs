using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Holonet3.Utilities
{
	interface ICryptable
	{
		long Crypted { get; set; }

		void OnCrypting(long crypterLevel);

		void OnDecryptSuccess(long crypterAccount);
	}
}
