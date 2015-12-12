using System;
using System.Collections.Generic;

namespace BusinessLayer
{
	/// <summary>
	/// Summary description for User
	/// </summary>
	public class Person
	{
		private string _firstName;
		private string _lastName;
		private DateTime _birthday;
		//private XmlDocument _em2008;

		public Person()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Person(string firstName, string lastName, DateTime birthday)
		{
			_firstName = firstName;
			_lastName = lastName;
			_birthday = birthday;
		}

		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public DateTime BirthDay
		{
			get { return _birthday; }
			set 
			{
				_birthday = value; 
			}
		}
	}
}