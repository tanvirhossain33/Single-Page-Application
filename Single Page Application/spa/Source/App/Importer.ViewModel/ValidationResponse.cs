using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importer.ViewModel
{
    public class ValidationResponse
    {
        public List<string> Errors { get; set; } = new List<string>();

        public bool IsValid => Errors.Count == 0;
        public string Message => Errors.Count > 0 ? string.Join(", ", Errors) : null;

    }
}
