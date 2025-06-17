using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker.UI.Models
{
    public class ResponseDto<T> where T: class
    {
        public bool IsSuccess { get; set; }
        public string ResponseMethod { get; set; }
        public string Message { get; set; }
        public List<T>? Data { get; set; }
    }
}
