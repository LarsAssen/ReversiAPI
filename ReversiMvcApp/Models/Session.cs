using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiMvcApp.Models
{
	public class Session
	{
		public DateTime Expires { get; set; }
		private Dictionary<string, object> _values = new Dictionary<string, object>();
		public bool Refresh { get; set; } = false;

		public Session(DateTime dateTime)
		{
			Expires = dateTime;
		}

		public Session()
		{
		}

		public void Clear()
		{
			_values.Clear();
		}

		public void Remove(string key)
		{
			_values.Remove(key);
		}

		public void Set(string key, object value)
		{
			_values[key] = value;
		}

		public bool TryGetValue<T>(string key, out T value)
		{
			if (!_values.ContainsKey(key))
			{
				value = default(T);
				return false;
			}

			value = (T)_values[key];

			if (!(value is T))
			{
				value = default(T);
				return false;
			}

			return true;
		}
	}
}
