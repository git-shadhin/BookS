using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;
using NHibernate.Tuple;

namespace BookS.Core.Models.MappedClasses
{
    public class AuthorMapping : Author
    {
        new public virtual int AuthorId
        {
            get { return mAuthorId; }
            set { base.AuthorId = value; }
        }

        new public virtual string Name
        {
            get { return mName; } 
            set { base.Name = value; }
        }

        new public virtual string Surname
        {
            get { return mSurname; } 
            set { base.Surname = value; }
        }

        new public virtual string DateOfBirth 
        {
            get { return mDateOfBirth.ToString("d"); } 
            set { mDateOfBirth = DateTime.Parse(value);}
        }

        new public virtual string Gender
        {
            get { return mGender.ToString(); } 
            set { base.Gender = (Gender)Enum.Parse(typeof(Gender), value, true); }
        }

        new public virtual IList<BookMapping> Books 
        { 
            get { return mBooks as IList<BookMapping>; }
            set { base.Books = value as IList<Book>; }
        }
    }
}
