using System;
using System.IO;
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

        public static void SaveJsonFile<T>( string savePath, T data ) where T : class
        {
            try
            {
				using(StreamWriter writer = new StreamWriter(savePath))
                {
					var settings = new JsonSerializerSettings
					{
						DateFormatHandling = DateFormatHandling.IsoDateFormat,
						Formatting = Formatting.Indented
					};
					writer.Write(JsonConvert.SerializeObject(data, settings));
                }
            }
            catch (Exception e)
            {
				throw e;
            }
        }

        public static string SaveJsonFileTest<T>( T data ) where T : class
        {
			try
			{
				var settings = new JsonSerializerSettings
				{
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					Formatting = Formatting.Indented
				};
				return JsonConvert.SerializeObject(data, settings);
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		#endregion

		#region - Full Properties

		#endregion
	}
}
