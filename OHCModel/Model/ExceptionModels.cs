using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCModel.Model
{
    public class ExceptionModels
    {
        public int Id { get; set; }
        public String ExceptionType { get; set; }
        public String BaseType { get; set; }
        public String Title { get; set; }
        public String Message { get; set; }
        public String StackTrace { get; set; }
        public String HelpLink { get; set; }
        public String Class { get; set; }
        public String Method { get; set; }
        public String LoggedUserId { get; set; }
        public String CreatedDate { get; set; }
        public List<ExceptionModels>exceptionModels { get; set; }   
    }
}
