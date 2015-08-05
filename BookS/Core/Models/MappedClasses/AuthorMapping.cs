﻿using System;
using System.Collections.Generic;
using BookS.Core.Maintenance;
using Gender = BookS.Core.Maintenance.Common.Gender;

namespace BookS.Core.Models.MappedClasses
{
    public class AuthorMapping
    {
        protected virtual int AuthorId { get; set; }
        protected virtual IList<Book> Books { get; set; }
        protected virtual string Name { get; set; }
        protected virtual string Surname { get; set; }
        protected virtual string DateOfBirth { get; set; }
        protected virtual Gender Gender { get; set; }
    }
}