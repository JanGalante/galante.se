using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for UserCollection
	/// </summary>
	public class PersonCollection : ICollection<Person>
	{//http://support.microsoft.com/kb/307484

		List<Person> _persons;

		public PersonCollection()
		{
			_persons = new List<Person>();
			//
			// TODO: Add constructor logic here
			//
		}


		#region ICollection<Person> Members

		public void Add(Person item)
		{
			//throw new NotImplementedException();
			//Person p = new Person();
			//p.FirstName = "nisse";
			_persons.Add(item);
		}

		//Denna har jag gjort själv. Ingår ej i interfacet
		public void Add(params Person[] persons)
		{
			//throw new NotImplementedException();
			//Person p = new Person();
			//p.FirstName = "nisse";
			foreach (Person item in persons)
			{
				_persons.Add(item);	
			}
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(Person item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(Person[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(Person item)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IEnumerable<Person> Members

		public IEnumerator<Person> GetEnumerator()
		{
			//throw new NotImplementedException();
			foreach (Person item in _persons)
			{
				yield return item;
			}
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			//throw new NotImplementedException();
			foreach (Person item in _persons)
			{
				yield return item;
			}
		}

		#endregion
	}
}
