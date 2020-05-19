using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ModelLibrary
{
    public static class JsonController
	{
		#region - Fields & Properties

		#endregion

		#region - Methods
		public static T OpenJsonFile<T>( string filePath ) where T : class
		{
			if (File.Exists(filePath))
			{
				try
				{
					using (StreamReader reader = new StreamReader(filePath))
					{
						return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
					}
				}
				catch (Exception e)
				{
					throw e;
				}
			}
			else
			{
				throw new FileNotFoundException("Couldnt find the file.");
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
