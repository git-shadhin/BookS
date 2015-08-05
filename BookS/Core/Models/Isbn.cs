using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookS.Core.Maintenance;

namespace BookS.Core.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Isbn : IValidator<Isbn>
    {
        private string mNumber;
        public string Number
        {
            get { return mNumber ?? String.Empty; }
            set { mNumber = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Isbn() : this("")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNumber"></param>
        public Isbn(string pNumber)
        {
            mNumber = pNumber;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject1"></param>
        /// <param name="pObject2"></param>
        /// <returns></returns>
        public bool? Compare(Isbn pObject1, Isbn pObject2)
        {
            throw new NotImplementedException();
        }
    }
}
