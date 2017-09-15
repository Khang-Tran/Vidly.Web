using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public Movies Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

    }
}