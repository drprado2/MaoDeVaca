using System;
using System.Collections.Generic;
using System.Text;

namespace MaoDeVaca.Domain.Dto
{
    public class DefaultResponse
    {
        public DefaultResponse()
        {
            Errors = new List<string>();
        }

        public object Data { get; set; }
        public IList<string> Errors { get; set; }
        public int TotalItems { get; set; }
    }
}
