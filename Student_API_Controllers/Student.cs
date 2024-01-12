namespace Student_API_Controllers
{
    public class Student
    {
        private int _id;
        private string _lastName;
        private string _firstName;
        private DateTime _birthdate;

        public Student (int id, string firstName, string lastName, DateTime birthDate)
        {
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._birthdate = birthDate;
        }

        public int getId()
        {
            return this._id;
        }
        public string getFirstName()
        {
            return this._firstName;
        }
        public string getLastName()
        {
            return this._lastName;
        }
        public DateTime getBirthDate()
        {
            return this._birthdate;
        }
    }
}
